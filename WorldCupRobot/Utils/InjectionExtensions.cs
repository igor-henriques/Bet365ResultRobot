namespace MainRobotOrchester.Utils;

public static class InjectionExtensions
{
    public static void ConfigureSettings(this IServiceCollection services)
    {
        services.AddSingleton(
            JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Configurations/Settings.json"))));
    }

    public static void ConfigureElementsXPathInjection(this IServiceCollection services)
    {
        services.AddSingleton(
            JsonConvert.DeserializeObject<ElementsXPath>(value: File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Configurations/ElementsXPath.json"))));
    }

    public static void ConfigureElementsCSSInjection(this IServiceCollection services)
    {
        services.AddSingleton(
            JsonConvert.DeserializeObject<ElementsCSS>(value: File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Configurations/ElementsCSS.json"))));
    }
}