using CommonDatabase.Enums;

namespace MainRobotOrchester.Workers;

internal class ResultadosWorker : BackgroundService
{
    public static bool IsAlive = false;
    private string lastClubeResult = string.Empty;
    private string lastWorldcupResult = string.Empty;

    private readonly Random random = new Random();
    private readonly ILogger<ResultadosWorker> logger;
    private readonly IResultadoRepository resultadoContext;
    private readonly ElementsLocators locators;
    private readonly Settings settings;
    private readonly IWebRepository webContext;
    private readonly ResultadoBuilder<ResultadosWorker> resultadoBuilder;

    public ResultadosWorker(ILogger<ResultadosWorker> logger, IResultadoRepository resultadoContext,
        ElementsLocators locators, Settings settings, IWebRepository webContext)
    {
        this.logger = logger;
        this.resultadoContext = resultadoContext;
        this.locators = locators;
        this.settings = settings;
        this.webContext = webContext;
        this.resultadoBuilder = new ResultadoBuilder<ResultadosWorker>(webContext, locators, logger);
    }

    public async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                webContext.Navigate(string.Format(locators.ResultadosClubes, DateTime.Now.ToString("yyyy-MM-dd")));

                var result = await webContext.GetElement(By.ClassName(locators.ResultItemClass));

                if (lastClubeResult != result.Text)
                {
                    await ScrapResultadoAsync(result, EventType.Clubes);
                }

                await Task.Delay(TimeSpan.FromSeconds(settings.UserDefinedRandomTime + random.Next(1, 3)));

                webContext.Navigate(string.Format(locators.ResultadosWorldcup, DateTime.Now.ToString("yyyy-MM-dd")));

                result = await webContext.GetElement(By.ClassName(locators.ResultItemClass));

                if (lastWorldcupResult != result.Text)
                {
                    await ScrapResultadoAsync(result, EventType.Worldcup);
                }

                await Task.Delay(TimeSpan.FromSeconds(settings.UserDefinedRandomTime + random.Next(1, 3)));
            }
        }
        catch (Exception e)
        {
            UILogger.UILogInformation(logger, e.ToString());

            webContext.Refresh();            
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IsAlive = true;

        if (!webContext.GetCurrentURL().Equals(string.Format(locators.ResultadosClubes, DateTime.Now.ToString("yyyy-MM-dd"))))
        {
            webContext.Navigate(string.Format(locators.ResultadosClubes, DateTime.Now.ToString("yyyy-MM-dd")));

            await Task.Delay(500);
        }

        var results = await webContext.GetElements(By.ClassName(locators.ResultItemClass));

        foreach (var model in results.Select((result, index) => (result, index)))
        {
            await ScrapResultadoAsync(model.result, EventType.Clubes);

            if (model.index == results.Count - 1)
            {
                lastClubeResult = model.result.Text;
            }
        }

        if (!webContext.GetCurrentURL().Equals(string.Format(locators.ResultadosWorldcup, DateTime.Now.ToString("yyyy-MM-dd"))))
        {
            webContext.Navigate(string.Format(locators.ResultadosWorldcup, DateTime.Now.ToString("yyyy-MM-dd")));

            await Task.Delay(500);
        }

        results = await webContext.GetElements(By.ClassName(locators.ResultItemClass));

        foreach (var model in results.Select((result, index) => (result, index)))
        {
            await ScrapResultadoAsync(model.result, EventType.Worldcup);

            if (model.index == results.Count - 1)
            {
                lastWorldcupResult = model.result.Text;
            }
        }

        await DoWorkAsync(stoppingToken).ConfigureAwait(false);
    }

    private async Task ScrapResultadoAsync(IWebElement resultadoElement, EventType eventType)
    {
        resultadoElement.FindElement(By.ClassName(locators.ResultItemHeaderClass)).Click();

        await Task.Delay(150);

        var resultado = await resultadoBuilder.BuildResultadoAsync(resultadoElement, eventType);

        if (resultado == null)
            return;

        await AddResultadoAsync(resultado);
    }

    private async Task AddResultadoAsync(Resultado resultado)
    {
        var response = await resultadoContext.AddAsync(resultado);

        if (response == null)
            return;

        UILogger.UILogInformation(logger, $"Resultado {response.NomeTimeCasa} vs {response.NomeTimeVisitante} ({response.Horario.Hour.ToString("00")}:{response.Horario.Minute.ToString("00")}) salvo no banco de dados - ID {response.Id}");
    }
}