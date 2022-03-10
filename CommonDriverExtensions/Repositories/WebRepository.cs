namespace CommonDriverExtensions.Repositories;

public class WebRepository : IWebRepository
{
    private readonly ChromeDriver _driver;

    private readonly WebDriverWait _wait;

    public WebRepository(ChromeDriver driver)
    {
        this._driver = driver;

        this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

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
            await WaitUntilElementExists(elementLocator);

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
            await WaitUntilElementExists(elementLocator);

        return await ValueTask.FromResult(_driver.FindElements(elementLocator));
    }

    public async ValueTask<string> GetElementContent(By elementLocator, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        return await ValueTask.FromResult(element.Text);
    }

    public async ValueTask ClickOnElement(By elementLocator, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        element.Click();
    }

    public async ValueTask InsertTextOnElement(By elementLocator, string text, bool verifyExistence = true)
    {
        var element = await GetElement(elementLocator, verifyExistence);

        element.SendKeys(text);
    }

    public async ValueTask<IWebElement> WaitUntilElementExists(By elementLocator)
    {
        MoveToPopUp();

        return await ValueTask.FromResult(_wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator)));
    }

    private void MoveToPopUp()
    {
        _driver.SwitchTo().ActiveElement();
    }

    public void StopDriver()
    {
        _driver?.Close();
    }

    public string GetCurrentURL()
    {
        return _driver.Url;
    }

    public void RefreshPage()
    {
        _driver.Navigate().Refresh();
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