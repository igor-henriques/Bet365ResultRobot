using SeleniumExtras.WaitHelpers;

namespace CommonDriverExtensions.Repositories;

public class WebRepository : IWebRepository
{
    private readonly ChromeDriver _driver;

    private readonly WebDriverWait _wait;

    public WebRepository(ChromeDriver driver)
    {
        this._driver = driver;

        this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        this._wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
    }

    public void Navigate(string URL)
    {
        _driver.Navigate().GoToUrl(URL);
    }

    public void Refresh()
    {
        _driver.Navigate().Refresh();
    }

    public async ValueTask<IWebElement> GetElement(By elementLocator, bool verifyExistence = true)
    {
        if (verifyExistence)
            WaitUntilElementExists(elementLocator);

        return await ValueTask.FromResult(_driver.FindElement(elementLocator));
    }

    public async ValueTask<IWebElement> GetLastEvent(By classEventTab)
    {
        var lastEvent = await GetElements(classEventTab);

        return lastEvent.Last();
    }

    public async ValueTask<IReadOnlyCollection<IWebElement>> GetElements(By elementLocator, bool verifyExistence = true)
    {
        if (verifyExistence)
            WaitUntilElementExists(elementLocator);

        return await ValueTask.FromResult(_driver.FindElements(elementLocator));
    }

    public async ValueTask<string> GetElementContent(By elementLocator, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        return await ValueTask.FromResult(element?.Text);
    }

    public async ValueTask ClickOnElement(By elementLocator, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        while (!element.Displayed | !element.Enabled)
            await Task.Delay(100);

        element.Click();
    }

    public async ValueTask InsertTextOnElement(By elementLocator, string text, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        element.SendKeys(text);
    }

    public void WaitUntilElementExists(By elementLocator)
    {
        _wait.Until(_driver =>
        {
            try
            {
                var func = ExpectedConditions.ElementIsVisible(elementLocator);

                var element = func.Invoke(_driver);

                return element != null;
            }
            catch { return false; }
        });
    }

    public void MoveToPopUp()
    {
        _driver.SwitchTo().ActiveElement();        
    }

    public void MoveToDefault()
    {
        _driver.SwitchTo().DefaultContent();
    }

    public void StopDriver()
    {
        _driver?.Close();
    }

    public string GetCurrentURL()
    {
        return _driver.Url;
    }

    public bool ElementExists(By elementLocator)
    {
        try
        {
            return _driver.FindElement(elementLocator) != null;
        }
        catch (Exception) { }

        return false;
    }
}