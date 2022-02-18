namespace CommonDriverExtensions.Repositories;

public class WebRepository : IWebRepository
{
    private readonly ChromeDriver _driver;

    private readonly WebDriverWait _wait;

    public WebRepository(ChromeDriver driver)
    {
        this._driver = driver;

        this._wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
    }

    /// <summary>
    /// Navegar à página especificada
    /// </summary>
    /// /// <param name="URL">URL destino</param>
    public void Navigate(string URL)
    {
        try
        {
            _driver.Navigate().GoToUrl(URL);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async ValueTask<IWebElement> GetElement(By elementLocator)
    {
        await WaitUntilElementExists(elementLocator);

        return await ValueTask.FromResult(_driver.FindElement(elementLocator));
    }

    public async ValueTask<string> GetElementContent(By elementLocator)
    {
        var element = await GetElement(elementLocator);

        return await ValueTask.FromResult(element.Text);
    }

    public async ValueTask ClickOnElement(By elementLocator)
    {
        var element = await GetElement(elementLocator);

        element.Click();
    }

    public async ValueTask InsertTextOnElement(By elementLocator, string text)
    {
        var element = await GetElement(elementLocator);

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
}