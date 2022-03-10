namespace MainRobotOrchester.Workers;

public class StartForm : BackgroundService
{
    private readonly IServiceProvider _services;
    public StartForm(IServiceProvider services)
    {
        this._services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000);

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(_services.GetRequiredService<MainForm>());
    }
}