namespace CommonDriverExtensions.Interfaces;

public interface IWebRepository
{
    ValueTask<IWebElement> GetElement(By elementLocator, bool verifyExistence = true);
    ValueTask<IReadOnlyCollection<IWebElement>> GetElements(By elementLocator, bool verifyExistence = true);
    void Navigate(string URL);
    ValueTask<IWebElement> WaitUntilElementExists(By elementLocator);
    ValueTask ClickOnElement(By elementLocator, bool verifyExistence = true);
    ValueTask InsertTextOnElement(By elementLocator, string text, bool verifyExistence = true);
    ValueTask<string> GetElementContent(By elementLocator, bool verifyExistence = true);
    void StopDriver();
    string GetCurrentURL();
    void RefreshPage();
    bool ElementExists(By elementLocator);
    ValueTask<IWebElement> GetLastEvent(By classEventTab);
    void Refresh();
}