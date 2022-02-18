namespace CommonDriverExtensions.Utils;

public class CleanDriverGarbage
{
    public static void Run()
    {
        foreach (Process instance in Process.GetProcessesByName("chrome"))
        {
            instance.Kill();
        }

        foreach (Process instance in Process.GetProcessesByName("chromedriver"))
        {
            instance.Kill();
        }

        foreach (Process instance in Process.GetProcessesByName("conhost"))
        {
            instance.Kill();
        }
    }
}