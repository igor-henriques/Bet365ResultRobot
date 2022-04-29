using CommonDatabase.Enums;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainRobotOrchester.Builders;

internal class ResultadoBuilder<T> where T : BackgroundService
{
    private readonly NumberFormatInfo decimalFormat = new NumberFormatInfo { NumberDecimalSeparator = "." };
    private readonly IWebRepository webRepository;
    private readonly ElementsLocators locators;
    private readonly ILogger<T> logger;

    public ResultadoBuilder(IWebRepository webRepository, ElementsLocators locators, ILogger<T> logger)
    {
        this.logger = logger;
        this.webRepository = webRepository;
        this.locators = locators;
    }

    public async Task<Resultado> BuildResultadoAsync(IWebElement currentResultado, EventType eventType)
    {
        var resultado = new Resultado();

        var informations = currentResultado.FindElements(By.TagName("div")).ElementAt(1).Text;        

        var horario = informations.Substring(0, 5);

        informations = informations.Replace(horario, string.Empty);

        var placar = Regex.Match(informations, @"([0-9]*) - ([0-9]*) ").Value;        

        var times = informations.Trim().Split("-");

        resultado = await AssignData(resultado, horario);

        resultado.NomeTimeCasa = ObterTime(times[0]);

        resultado.NomeTimeVisitante = ObterTime(times[1]);

        var placarArray = placar.Replace(" ", string.Empty).Split('-');

        resultado.PontuacaoTimeCasa = short.Parse(placarArray[0], decimalFormat);

        resultado.PontuacaoTimeVisitante = short.Parse(placarArray[1], decimalFormat);

        resultado.TipoEvento = eventType;

        resultado.TotalGols = (short)(resultado.PontuacaoTimeCasa + resultado.PontuacaoTimeVisitante);

        return resultado;
    }

    private string ObterTime(string time)
    {
        var _time = new string(time.Where(c => char.IsLetter(c)).ToArray()).Trim();

        var resultado = string.Empty;

        foreach (var character in _time)
        {
            if (char.IsUpper(character))
            {
                resultado += " ";

            }

            resultado += character;
        }

        return resultado.Trim();
    }

    private async ValueTask<Resultado> AssignData(Resultado resultado, string horario)
    {
        var hourMinuteEventDate = horario.Split(':');

        int hour = int.Parse(hourMinuteEventDate[0]);
        int minute = int.Parse(hourMinuteEventDate[1]);

        resultado.Horario = new DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
            hour is 0 & minute <= 30 & DateTime.Now.Hour is 23 ? DateTime.Now.Day + 1 : DateTime.Now.Day,
            hour,
            minute,
            0,
            0);

        return await ValueTask.FromResult(resultado);
    }
}
