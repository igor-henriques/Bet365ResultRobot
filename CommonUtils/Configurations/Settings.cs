namespace CommonUtils.Configurations;

public record Settings
{
    public static string ConnectionString
    {
        get
        {
            JObject jsonNodes = (JObject)JsonConvert.DeserializeObject(File.ReadAllText("./Configurations/ConnectionStrings.json"));

            return jsonNodes["Default"].ToObject<string>();
        }
    }
}