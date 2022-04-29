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
    public int SecondsPausedEachIteration { get; set; }
    public int UserDefinedRandomTime { get; set; }
    public int TimeToResetLogsInHours { get; set; }
    public bool IsDescritiveOperationsEnabled { get; set; } = false;
}