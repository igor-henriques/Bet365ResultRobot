namespace CommonDriverExtensions.Utils;

public class CleanDriverGarbage
{
    public static void Run()
    {
        foreach (Process instance in Process.GetProcessesByName("chrome"))
        {
            try
            {
                instance.Kill();
            }
            catch (Exception) { }            
        }

        foreach (Process instance in Process.GetProcessesByName("chromedriver"))
        {
            try
            {
                instance.Kill();
            }
            catch (Exception) { }
        }

        foreach (Process instance in Process.GetProcessesByName("conhost"))
        {
            try
            {
                instance.Kill();
            }
            catch (Exception) { }
        }
    }
}