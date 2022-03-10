namespace MainRobotOrchester.Workers;

public class SuperleagueWorker : BackgroundService, IWorker
{
    public static bool IsAlive = false;

    private readonly IWebRepository webRepository;
    private readonly ILogger<SuperleagueWorker> logger;
    private readonly ElementsXPath elementsXPath;
    private readonly ElementsCSS elementsCSS;
    private readonly Settings settings;
    private readonly IOddRepository oddRepository;
    private readonly ITeamRepository teamRepository;
    private readonly IMatchNextRepository matchNextRepository;
    private string lastEventText = string.Empty;
    private readonly OddBuilder<SuperleagueWorker> oddBuilder;

    public SuperleagueWorker(IWebRepository webRepository, ILogger<SuperleagueWorker> logger, ElementsXPath elementsXPath,
        ElementsCSS elementsCSS, Settings settings, IOddRepository oddRepository, ITeamRepository teamRepository, IMatchNextRepository matchNextRepository)
    {
        this.webRepository = webRepository;
        this.logger = logger;
        this.elementsXPath = elementsXPath;
        this.elementsCSS = elementsCSS;
        this.settings = settings;
        this.oddRepository = oddRepository;
        this.teamRepository = teamRepository;
        this.matchNextRepository = matchNextRepository;
        this.oddBuilder = new OddBuilder<SuperleagueWorker>(webRepository, settings, elementsXPath, elementsCSS, logger);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                IsAlive = true;

                await DoWorkAsync();
            }
            catch (Exception e)
            {
                IsAlive = false;

                logger.UILogInformation(e.ToString(), Microsoft.Extensions.Logging.LogLevel.Critical);

                webRepository.Refresh();

                await DoWorkAsync();
            }

            logger.UILogInformation($"Pausando por {settings.SecondsPausedEachIteration} segundos antes da próxima iteração");

            await Task.Delay(TimeSpan.FromSeconds(settings.SecondsPausedEachIteration));
        }
    }

    public async Task DoWorkAsync()
    {
        if (!webRepository.GetCurrentURL().Equals(elementsXPath.VirtualFutebolURL))
        {
            webRepository.Navigate(elementsXPath.VirtualFutebolURL);
            await webRepository.ClickOnElement(By.XPath(elementsXPath.SuperleagueElements.BrowserTabPath));
        }

        while (!await CheckEventTabAvailable())
            await webRepository.ClickOnElement(By.XPath(elementsXPath.SuperleagueElements.BrowserTabPath), false);

        if (!lastEventText.Any())
        {
            await ScrapAllEvents();

            await SetLastEventValue();
        }
        else
        {
            var lastEventScrapped = await webRepository.GetLastEvent(By.ClassName(elementsCSS.EventTab));

            if (lastEventScrapped.Text != lastEventText)
            {
                lastEventText = lastEventScrapped.Text;

                await ScrapEvent(lastEventScrapped);
            }
        }

        logger.UILogInformation("Iteração finalizada");
    }

    public void StopDriver()
    {
        webRepository.StopDriver();
    }

    public async Task<bool> CheckEventTabAvailable()
    {
        var element = await webRepository.GetElements(By.XPath(elementsXPath.Events.BrowserTabContent), false);

        return element.Count > 0;
    }

    public async Task ScrapAllEvents()
    {
        var eventsProperties = elementsXPath.Events.GetType().GetProperties();

        for (int i = 1; i < eventsProperties.Length; i++)
        {
            //Quando tem evento iniciado, há somente 6 Events pra analisar, em vez de 7, então break para não entrar no 7º Event
            if (i == eventsProperties.Length - 1 && !await IsEventStarted()) break;

            var currentEventValue = eventsProperties[i].GetValue(elementsXPath.Events).ToString();

            while (!await CheckEventTabAvailable())
                await webRepository.ClickOnElement(By.XPath(elementsXPath.SuperleagueElements.BrowserTabPath));

            if (i == 1 & await IsEventStarted()) continue;

            await ScrapEvent(await webRepository.GetElement(By.XPath(currentEventValue)));
        }
    }
    public async Task ScrapEvent(IWebElement element)
    {
        try
        {
            element?.Click();

            await Task.Delay(500);

            var eventSchedule = await webRepository.GetElementContent(By.ClassName(elementsCSS.SelectedEvent));
            var nomeTimeCasa = await webRepository.GetElementContent(By.XPath(elementsXPath.NomeTimeCasa));
            var nomeTimeVisitante = await webRepository.GetElementContent(By.XPath(elementsXPath.NomeTimeVisitante));

            logger.UILogInformation($"Extraindo dados do evento {eventSchedule} - {nomeTimeCasa} vs {nomeTimeVisitante}");

            var odd = await oddBuilder.BuildOddAsync();

            await ResolveData(odd, nomeTimeVisitante, nomeTimeCasa, eventSchedule);
        }
        catch (Exception e)
        {
            logger.UILogInformation(e.ToString());
        }
    }

    public async Task ResolveData(Odd odd, string nomeTimeVisitante, string nomeTimeCasa, string eventSchedule)
    {
        if (odd != null)
        {
            var splittedEventSchedule = eventSchedule.Split(':');

            var matchDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, int.Parse(splittedEventSchedule[1]), 0);

            odd.IdTeamAway = (await teamRepository.GetByNameAsync(nomeTimeVisitante)).Id;
            odd.IdTeamHome = (await teamRepository.GetByNameAsync(nomeTimeCasa)).Id;

            MatchNext matchNext = new()
            {
                IdCompetition = settings.SuperleagueIdCompetition,
                IsStarted = await IsEventStarted(),
                TimeCasa = nomeTimeCasa,
                TimeVisitante = nomeTimeVisitante,
                IdTeamHome = odd.IdTeamHome,
                IdTeamAway = odd.IdTeamAway,
                Date = matchDate,
                DataInicioJogo = DateTime.Parse("1900-01-01 00:00:00.000"),
                Tempo = eventSchedule,
                UserDate = matchDate.AddHours(-3),
                SendTelegramConfrontos = false
            };

            await matchNextRepository.InsertAsync(matchNext);

            odd.IdMatchNext = (int)matchNext.Id;

            await oddRepository.InsertAsync(odd);

            if (settings.IsDescritiveOperationsEnabled)
            {
                logger.UILogInformation($"Odd ID {odd.Id} adicionado ao banco de dados.");
                logger.UILogInformation($"Match ID {matchNext.Id} adicionado ao banco de dados.");
            }
        }
    }

    public async Task SetLastEventValue()
    {
        this.lastEventText = (await webRepository.GetLastEvent(By.ClassName(elementsCSS.EventTab))).Text;
    }

    public async Task<bool> IsEventStarted()
    {
        var elements = await webRepository.GetElements(By.ClassName(elementsCSS.EventTab));
        var counter = await webRepository.GetElementContent(By.XPath(elementsXPath.CounterGameStop), false);

        if (counter?.Length > 0)
        {
            var timeSpan = TimeSpan.FromSeconds(int.Parse(counter.Split(':')[0]) * 60 + int.Parse(counter.Split(':')[1])).TotalSeconds;

            return elements.Count() == 7 | timeSpan <= 2;
        }
        else
        {
            return elements.Count() == 7;
        }
    }
}
