namespace MainRobotOrchester.Workers;

internal class PremiershipWorker : BackgroundService
{
    public static bool IsAlive = false;

    private readonly IWebRepository webRepository;
    private readonly ILogger<PremiershipWorker> logger;

    public PremiershipWorker(IWebRepository webRepository, ILogger<PremiershipWorker> logger)
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

            IsAlive = false;
        }
    }

    private async Task DoWorkAsync()
    {
        webRepository.Navigate("https://www.google.com");

        logger.LogInformation("Work done");
    }
}
