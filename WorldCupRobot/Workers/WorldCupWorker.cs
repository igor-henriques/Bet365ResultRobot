namespace MainRobotOrchester.Workers;

internal class WorldCupWorker : BackgroundService, IWorker
{
    public static bool IsAlive = false;

    private readonly Random random = new Random();
    private readonly ILogger<WorldCupWorker> logger;
    private readonly IOddRepository oddContext;
    private readonly Settings settings;
    private readonly IWebRepository webContext;
    private string lastEventText = string.Empty;
    private readonly ElementsLocators locators;

    public WorldCupWorker(ILogger<WorldCupWorker> logger, IOddRepository oddContext,
        Settings settings, IWebRepository webContext, ElementsLocators locators)
    {
        this.logger = logger;
        this.oddContext = oddContext;
        this.settings = settings;
        this.webContext = webContext;
        this.locators = locators;
    }

    public async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(2000);

        await ScrapAllEvents();

        await Task.Delay(TimeSpan.FromSeconds(settings.UserDefinedRandomTime + random.Next(1, 3)));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                webContext.Refresh();

                await Task.Delay(1000);

                var lastEvent = await ClickAndGetLastEvent();

                if (lastEvent.Item1.Text != lastEventText)
                {
                    await ScrapEvent(lastEvent.Item1, lastEvent.Item2 - 1);
                    lastEventText = lastEvent.Item1.Text;
                }
            }
            catch (Exception e)
            {
                UILogger.UILogInformation(logger, e.ToString(), Microsoft.Extensions.Logging.LogLevel.Critical);
            }

            await Task.Delay(TimeSpan.FromSeconds(settings.UserDefinedRandomTime + random.Next(1, 3)));
        }
    }

    public async Task<(IWebElement, int)> ClickAndGetLastEvent()
    {
        var slide = await webContext.GetElement(By.XPath(locators.DatesSliderXPath));

        var events = slide.FindElements(By.TagName("span"));

        var lastEventOnWeb = events.LastOrDefault();

        while (!lastEventOnWeb.Displayed)
        {
            await webContext.ClickOnElement(By.XPath(locators.SlideRightArrow));

            await Task.Delay(100);
        }

        lastEventOnWeb.Click();

        return (lastEventOnWeb, events.Count);
    }

    public async Task<bool> IsEventStarted(IWebElement _event, int eventIndex)
    {
        try
        {
            var dateNow = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";

            if (_event.Text.Equals(dateNow))
                return true;

            var eventStartedSpan = await webContext.GetElement(By.XPath(string.Format(locators.AoVivoDescriptionCopaMundoXPath, eventIndex + 1)), false);

            if (eventStartedSpan.Displayed)
                return true;

            return false;
        }
        catch (Exception)
        {
            return true;
        }
    }

    public Task ResolveData(Odd odd, string nomeTimeVisitante, string nomeTimeCasa, string eventSchedule)
    {
        throw new NotImplementedException();
    }

    public async Task ScrapAllEvents()
    {
        try
        {
            if (!webContext.GetCurrentURL().Equals(locators.MainURL + locators.WorldcupSubURL))
            {
                webContext.Navigate(locators.MainURL + locators.WorldcupSubURL);

                await Task.Delay(500);
            }

            var slide = await webContext.GetElement(By.XPath(locators.DatesSliderXPath));

            var events = slide.FindElements(By.TagName("span"));

            foreach (var model in events.Select((currentEvent, index) => (currentEvent, index)))
            {
                while (await IsEventStarted(model.currentEvent, model.index))
                {
                    await Task.Delay(5000);

                    webContext.Refresh();

                    await ScrapAllEvents();

                    return;
                }

                while (!model.currentEvent.Displayed)
                    await webContext.ClickOnElement(By.XPath(locators.SlideRightArrow));

                model.currentEvent.Click();

                await Task.Delay(1000);

                await ScrapEvent(model.currentEvent, model.index);

                if (model.index == events.Count - 1)
                    lastEventText = model.currentEvent.Text;
            }
        }
        catch (Exception e)
        {
            UILogger.UILogInformation(logger, e.ToString(), Microsoft.Extensions.Logging.LogLevel.Critical);

            webContext.Refresh();

            await ScrapAllEvents();
        }
    }

    public async Task ScrapEvent(IWebElement element, int index)
    {
        var oddBuilder = new OddBuilder<WorldCupWorker>(webContext, locators, logger);

        var odd = await oddBuilder.BuildOddAsync(element, index);

        if (odd is null)
            return;

        await SaveOddAsync(odd);
    }

    public async Task SaveOddAsync(Odd odd)
    {
        var response = await oddContext.AddAsync(odd);

        if (response != null)
            UILogger.UILogInformation(logger, $"Odd {response.NomeTimeCasa} vs {response.NomeTimeVisitante}({response.DataInicio.Hour.ToString("00")}:{response.DataInicio.Minute.ToString("00")}) salva no banco de dados - ID: {response.Id}");
    }

    public async Task SetLastEventValue()
    {
        var slide = await webContext.GetElement(By.XPath(locators.DatesSliderXPath));

        var events = slide.FindElements(By.TagName("span"));

        var lastEventOnWeb = events.LastOrDefault()?.Text;

        if (lastEventText != lastEventOnWeb)
            this.lastEventText = lastEventOnWeb;
    }

    public void StopDriver()
    {
        webContext.StopDriver();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IsAlive = true;

        await DoWorkAsync(stoppingToken);
    }
}
