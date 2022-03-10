namespace MainRobotOrchester.Utils;

public static class UILogger
{
    public static void UILogInformation<T>(this ILogger<T> logger, string content, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
    {
        try
        {
            logger.Log(logLevel, content);

            var workerName = typeof(T).Name.Replace("Worker", string.Empty).ToUpper().Trim();

            var list = workerName switch
            {
                "EUROCUP" => MainForm.eurocupLogs,
                "PREMIERSHIP" => MainForm.premiershipLogs,
                "SUPERLEAGUE" => MainForm.superleagueLogs,
                "WORLDCUP" => MainForm.worldcupLogs,
                _ => new List<string>()
            };

            var logText = $"{workerName} - {logLevel.ToString().ToUpper()} LOG ENTRY: {content}\n";

            list.Add(logText);
        }
        catch (Exception) { }
    }
}