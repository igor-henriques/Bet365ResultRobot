string connectionString = Settings.ConnectionString;

Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddHostedService<StartService>();

        services.AddDbContext<Bet365RobotContext>();
        services.AddTransient<MainForm>();

        services.AddLogging(
        builder =>
        {
            builder.AddFilter("Microsoft", LogLevel.Warning)
                   .AddFilter("System", LogLevel.Warning)
                   .AddFilter("NToastNotify", LogLevel.Warning)
                   .AddConsole();
        }
        );
    })
    .RunConsoleAsync();