namespace MainRobotOrchester.Builders;

public class OddBuilder<T> where T : BackgroundService
{
    private readonly NumberFormatInfo decimalFormat = new NumberFormatInfo { NumberDecimalSeparator = "." };
    private readonly IWebRepository webRepository;
    private readonly ElementsLocators locators;
    private readonly ILogger<T> logger;
    private int currentEventIndex;

    public OddBuilder(IWebRepository webRepository, ElementsLocators locators, ILogger<T> logger)
    {
        this.logger = logger;
        this.webRepository = webRepository;
        this.locators = locators;
    }

    public async Task<Odd> BuildOddAsync(IWebElement currentEvent, int eventIndex)
    {
        try
        {
            this.currentEventIndex = eventIndex;

            Odd odd = new();

            var competition = typeof(T).Name.Replace("Worker", string.Empty);

            odd.NomeCompeticao = await webRepository.GetElementContent(By.XPath(string.Format(locators.NomeCompeticaoXPath, currentEventIndex + 1)));

            odd.TipoEvento = competition.Equals("Clubes") ? CommonDatabase.Enums.EventType.Clubes : CommonDatabase.Enums.EventType.Worldcup;

            odd = await ScrapEventDate(odd, currentEvent);

            odd = await ScrapProbabilidadeSectionAsync(odd);

            odd = await ScrapMaisMenosDe2_5GolsSectionAsync(odd);

            odd = await ScrapPontuacaoCorretaSectionAsync(odd);

            odd = await ScrapDuplaSectionAsync(odd);

            odd = await ScrapNumeroTotalGolsSectionAsync(odd);

            return odd;
        }
        catch (Exception e)
        {
            UILogger.UILogInformation(logger, e.ToString(), Microsoft.Extensions.Logging.LogLevel.Critical);

            return null;
        }
    }

    private async ValueTask<Odd> ScrapEventDate(Odd odd, IWebElement currentEvent)
    {
        var hourMinuteEventDate = currentEvent.Text.Split(':');

        int hour = int.Parse(hourMinuteEventDate[0]);
        int minute = int.Parse(hourMinuteEventDate[1]);

        odd.DataInicio = new DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
            hour is 0 & minute <= 30 & DateTime.Now.Hour is 23 ? DateTime.Now.Day + 1 : DateTime.Now.Day,
            hour,
            minute,
            0,
            0);

        return await ValueTask.FromResult(odd);
    }

    private async ValueTask<Odd> ScrapNumeroTotalGolsSectionAsync(Odd odd)
    {
        var numeroTotalGolsDiv = await webRepository.GetElement(By.XPath(string.Format(locators.NumeroTotalGolsXPath, currentEventIndex + 1)));

        var valueSpans = numeroTotalGolsDiv.FindElements(By.TagName("span"));

        odd.Total0Gols = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.Total1Gols = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);
        odd.Total2Gols = decimal.Parse(valueSpans.ElementAt(2).Text, decimalFormat);
        odd.Total3Gols = decimal.Parse(valueSpans.ElementAt(3).Text, decimalFormat);
        odd.Total4Gols = decimal.Parse(valueSpans.ElementAt(4).Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async ValueTask<Odd> ScrapDuplaSectionAsync(Odd odd)
    {
        var duplaDiv = await webRepository.GetElement(By.XPath(string.Format(locators.DuplaXPath, currentEventIndex + 1)));

        var valueSpans = duplaDiv.FindElements(By.TagName("span"));

        odd.VisitadoOuEmpate = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.VisitadoOuVisitante = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);
        odd.EmpateOuVisitante = decimal.Parse(valueSpans.ElementAt(2).Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async ValueTask<Odd> ScrapPontuacaoCorretaSectionAsync(Odd odd)
    {
        var pontuacaoCorretaMainDiv = await webRepository.GetElement(By.XPath(string.Format(locators.PontuacaoCorretaXPath, currentEventIndex + 1)));

        var pontuacaoCorretaDivs = pontuacaoCorretaMainDiv.FindElement(By.XPath(string.Format(locators.PontuacaoCorretaDivsXPath, currentEventIndex + 1, 1)));

        var valueSpans = pontuacaoCorretaDivs.FindElements(By.TagName("span"));

        odd.PontuacaoCorretaTimeCasa_1_0 = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.PontuacaoCorretaTimeCasa_2_0 = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);
        odd.PontuacaoCorretaTimeCasa_2_1 = decimal.Parse(valueSpans.ElementAt(2).Text, decimalFormat);

        pontuacaoCorretaDivs = pontuacaoCorretaMainDiv.FindElement(By.XPath(string.Format(locators.PontuacaoCorretaDivsXPath, currentEventIndex + 1, 2)));
        valueSpans = pontuacaoCorretaDivs.FindElements(By.TagName("span"));

        odd.PontuacaoCorretaEmpate_1_0 = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.PontuacaoCorretaEmpate_2_0 = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);
        odd.PontuacaoCorretaEmpate_2_1 = decimal.Parse(valueSpans.ElementAt(2).Text, decimalFormat);

        pontuacaoCorretaDivs = pontuacaoCorretaMainDiv.FindElement(By.XPath(string.Format(locators.PontuacaoCorretaDivsXPath, currentEventIndex + 1, 3)));
        valueSpans = pontuacaoCorretaDivs.FindElements(By.TagName("span"));

        odd.PontuacaoCorretaTimeVisitante_1_0 = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.PontuacaoCorretaTimeVisitante_2_0 = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);
        odd.PontuacaoCorretaTimeVisitante_2_1 = decimal.Parse(valueSpans.ElementAt(2).Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async ValueTask<Odd> ScrapMaisMenosDe2_5GolsSectionAsync(Odd odd)
    {
        var maisMenosGolsDiv = await webRepository.GetElement(By.XPath(string.Format(locators.MaisMenosDe2_5GolsXPath, currentEventIndex + 1)));

        var valueSpans = maisMenosGolsDiv.FindElements(By.TagName("span"));

        odd.MenosDe2_5Gols = decimal.Parse(valueSpans.ElementAt(0).Text, decimalFormat);
        odd.MaisDe2_5Gols = decimal.Parse(valueSpans.ElementAt(1).Text, decimalFormat);

        return await ValueTask.FromResult(odd);
    }

    private async ValueTask<Odd> ScrapProbabilidadeSectionAsync(Odd odd)
    {
        var probabilidadeDiv = await webRepository.GetElement(By.XPath(string.Format(locators.ProbabilidadesXPath, currentEventIndex + 1)));

        var probabilidadeSpans = probabilidadeDiv.FindElements(By.TagName("span"));

        var nomesTimes = probabilidadeDiv.FindElements(By.ClassName(locators.NomeTimesClass));

        odd.ProbabilidadeVitoriaTimeCasa = decimal.Parse(probabilidadeSpans.ElementAt(0).Text, decimalFormat);
        odd.ProbabilidadeVitoriaTimeVisitante = decimal.Parse(probabilidadeSpans.ElementAt(1).Text, decimalFormat);
        odd.ProbabilidadeEmpate = decimal.Parse(probabilidadeSpans.ElementAt(2).Text, decimalFormat);
        odd.NomeTimeCasa = nomesTimes.ElementAt(0).Text;
        odd.NomeTimeVisitante = nomesTimes.ElementAt(2).Text;

        return await ValueTask.FromResult(odd);
    }
}