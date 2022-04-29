namespace MainRobotOrchester.Workers;

public class StartForm : BackgroundService
{
    private readonly IServiceProvider _services;
    public StartForm(IServiceProvider services)
    {
        this._services = services;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(_services.GetRequiredService<MainForm>());

        return Task.CompletedTask;
    }
}