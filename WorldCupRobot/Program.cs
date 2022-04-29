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

options.AddExcludedArgument("enable-automation");
options.AddAdditionalOption("useAutomationExtension", false);

options.AddExtension(Path.Combine(Environment.CurrentDirectory, "cookie-notice-block.crx"));

await Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.ConfigureSettings();

        services.AddDbContext<BetfairDataContext>(options =>
        {
            options.UseSqlServer(Settings.ConnectionString);
        }, ServiceLifetime.Transient);

        services.AddSingleton<MainForm>();
        services.AddTransient<IOddRepository, OddRepository>();
        services.AddTransient<IResultadoRepository, ResultadoRepository>();

        services.AddTransient<ChromeDriver>(provider => new ChromeDriver(driverService, options));
        services.AddTransient<IWebRepository, WebRepository>();        

        services.AddHostedService<ClubesWorker>();
        services.AddHostedService<WorldCupWorker>();
        services.AddHostedService<ResultadosWorker>();

        services.AddHostedService<StartForm>();
    })
    .Build()
    .RunAsync();