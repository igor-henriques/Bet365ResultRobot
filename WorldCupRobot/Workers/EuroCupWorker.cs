namespace MainRobotOrchester.Workers;

internal class EuroCupWorker : BackgroundService
{
    public static bool IsAlive = false;

    private readonly IWebRepository webRepository;
    private readonly ILogger<EuroCupWorker> logger;
    private readonly ElementsXPath xPathElements;

    public EuroCupWorker(IWebRepository webRepository, ILogger<EuroCupWorker> logger, IOptions<ElementsXPath> xPathElements)
    {
        this.webRepository = webRepository;
        this.logger = logger;
        this.xPathElements = xPathElements.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var delayTimeAfterWork = await DoWorkAsync();

            var firstOdd = webRepository.GetElementContent(By.XPath(xPathElements.EuroCupFirstOdd));

            await Task.Delay(delayTimeAfterWork);

            IsAlive = true;
        }
    }

    private async Task<int> DoWorkAsync()
    {
        webRepository.Navigate("https://www.facebook.com");

        logger.LogInformation("Work done");

        return 60;
    }
}
