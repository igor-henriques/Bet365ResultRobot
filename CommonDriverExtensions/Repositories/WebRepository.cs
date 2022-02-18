using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDriverExtensions.Repositories;

public class WebRepository
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
    public async Task Navigate(string URL)
    {
        try
        {
            _driver.Navigate().GoToUrl(URL);

            await Task.Delay(1000);

            //LogWriter.Write($"Navegado à página {URL}");
        }
        catch (Exception)
        {
            throw;
        }
    }
}