CleanDriverGarbage.Run();

ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
driverService.HideCommandPromptWindow = true;

ChromeOptions options = new ChromeOptions();
options.AddArguments(new List<string>()
{
    /*"--no-startup-window",
    "no-sandbox"
    "headless"*/
});


string connectionString = Settings.ConnectionString;

await Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        //services.ConfigureElementsXPathInjection();

        services.AddDbContext<Bet365RobotContext>();

        services.AddSingleton<MainForm>();

        services.AddTransient<ChromeDriver>(provider => new ChromeDriver(driverService, options));
        services.AddTransient<IWebRepository, WebRepository>();

        services.AddHostedService<EuroCupWorker>();
        services.AddHostedService<PremiershipWorker>();
        services.AddHostedService<SuperleagueWorker>();
        services.AddHostedService<WorldCupWorker>();

        services.AddHostedService<StartForm>();

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