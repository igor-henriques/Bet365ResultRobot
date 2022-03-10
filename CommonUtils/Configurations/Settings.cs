namespace CommonUtils.Configurations;

public record Settings
{
    public static string ConnectionString
    {
        get
        {
            JObject jsonNodes = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configurations/Settings.json"));

            return jsonNodes["ConnectionString"].ToObject<string>();
        }
    }
    public int SecondsPausedEachIteration { get; set; } = 30;
    public int UserDefinedRandomTime { get; set; } = 10;
    public int TimeToResetLogsInHours { get; set; } = 24;
    public int WorldCupIdCompetition { get; set; } = 20120650;
    public int EuroCupIdCompetition { get; set; } = 20700663;
    public int SuperleagueIdCompetition { get; set; } = 20120654;
    public int PremiershipIdCompetition { get; set; } = 20120653;
    public bool IsDescritiveOperationsEnabled { get; set; } = false;
}