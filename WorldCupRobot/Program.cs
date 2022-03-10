CleanDriverGarbage.Run();

ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
driverService.HideCommandPromptWindow = true;

ChromeOptions options = new ChromeOptions();
options.AddArguments(new List<string>()
{
    "--disable-blink-features=AutomationControlled",
    "--disable-dev-shm-usage",
    "--no-sandbox",
    "--disable-impl-side-painting",
    "--disable-setuid-sandbox",
    "--disable-seccomp-filter-sandbox",
    "--disable-breakpad",
    "--disable-client-side-phishing-detection",
    "--disable-cast",
    "--disable-cast-streaming-hw-encoding",
    "--disable-cloud-import",
    "--disable-popup-blocking",
    "--ignore-certificate-errors",
    "--disable-session-crashed-bubble",
    "--disable-ipv6",
    "--allow-http-screen-capture",
    "--start-maximized"
});

string connectionString = Settings.ConnectionString;

await Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.ConfigureSettings();
        services.ConfigureElementsXPathInjection();
        services.ConfigureElementsCSSInjection();

        services.AddDbContext<Bet365RobotContext>(options =>
        {
            options.UseSqlServer(connectionString);
        }, ServiceLifetime.Transient);

        services.AddSingleton<MainForm>();
        services.AddTransient<IOddRepository, OddRepository>();
        services.AddTransient<ITeamRepository, TeamRepository>();
        services.AddTransient<IMatchNextRepository, MatchNextRepository>();

        services.AddTransient<ChromeDriver>(provider => new ChromeDriver(driverService, options));
        services.AddTransient<IWebRepository, WebRepository>();

        services.AddHostedService<StartForm>();

        services.AddHostedService<EuroCupWorker>();
        services.AddHostedService<PremiershipWorker>();
        services.AddHostedService<SuperleagueWorker>();
        services.AddHostedService<WorldCupWorker>();

        services.AddLogging(builder =>
        {
            builder.AddFilter("Microsoft", Microsoft.Extensions.Logging.LogLevel.Warning)
                   .AddFilter("System", Microsoft.Extensions.Logging.LogLevel.Warning)
                   .AddFilter("NToastNotify", Microsoft.Extensions.Logging.LogLevel.Warning)
                   .AddConsole();
        });
    })
    .Build()
    .RunAsync();