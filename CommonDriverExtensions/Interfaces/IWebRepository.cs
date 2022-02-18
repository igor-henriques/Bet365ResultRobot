namespace CommonDriverExtensions.Interfaces;

public interface IWebRepository
{
    ValueTask<IWebElement> GetElement(By elementLocator);
    void Navigate(string URL);
    ValueTask<IWebElement> WaitUntilElementExists(By elementLocator);
    ValueTask ClickOnElement(By elementLocator);
    ValueTask InsertTextOnElement(By elementLocator, string text);
    ValueTask<string> GetElementContent(By elementLocator);
}