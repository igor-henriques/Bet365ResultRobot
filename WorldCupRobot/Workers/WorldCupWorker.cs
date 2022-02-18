namespace MainRobotOrchester.Workers;

internal class WorldCupWorker : BackgroundService
{
    public static bool IsAlive = false;

    private readonly IWebRepository webRepository;
    private readonly ILogger<WorldCupWorker> logger;

    public WorldCupWorker(IWebRepository webRepository, ILogger<WorldCupWorker> logger)
    {
        this.webRepository = webRepository;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DoWorkAsync();

            await Task.Delay(15000);

            IsAlive = true;
        }
    }

    private async Task DoWorkAsync()
    {
        webRepository.Navigate("https://www.bet365.com/#/AVR/B146/R^1/");

        logger.LogInformation("Work done");
    }
}
