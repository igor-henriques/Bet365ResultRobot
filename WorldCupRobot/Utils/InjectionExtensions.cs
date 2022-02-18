namespace MainRobotOrchester.Utils;

public static class InjectionExtensions
{
    public static void ConfigureElementsXPathInjection(this IServiceCollection services)
    {
        services.Configure<ElementsXPath>(x =>
        {
            JsonConvert.DeserializeObject<ElementsXPath>("");
        });
    }
}