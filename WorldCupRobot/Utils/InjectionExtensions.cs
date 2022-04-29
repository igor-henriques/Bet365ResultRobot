namespace MainRobotOrchester.Utils;

public static class InjectionExtensions
{
    public static void ConfigureSettings(this IServiceCollection services)
    {
        services.AddSingleton(
            JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Configurations/Settings.json"))));

        services.AddSingleton(
            JsonConvert.DeserializeObject<ElementsLocators>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Configurations/ElementsLocators.json"))));
    }
}