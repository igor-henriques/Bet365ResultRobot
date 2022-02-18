namespace MainRobotOrchester.Workers;

internal class SuperleagueWorker : BackgroundService
{
    public static bool IsAlive = false;

    private readonly IWebRepository webRepository;
    private readonly ILogger<SuperleagueWorker> logger;

    public SuperleagueWorker(IWebRepository webRepository, ILogger<SuperleagueWorker> logger)
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
        webRepository.Navigate("https://www.github.com");

        logger.LogInformation("Work done");
    }
}
