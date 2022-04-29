namespace CommonDriverExtensions.Utils;

[Serializable]
public record ElementsLocators
{
    public string MainURL { get; init; }
    public string CookieAcceptButtonXPath { get; init; }
    public string SlideLeftArrow { get; init; }
    public string SlideRightArrow { get; init; }
    public string ClubesSubURL { get; init; }
    public string WorldcupSubURL { get; init; }
    public string DatesSliderXPath { get; init; }
    public string ProbabilidadesXPath { get; init; }
    public string MaisMenosDe2_5GolsXPath { get; init; }
    public string PontuacaoCorretaXPath { get; init; }
    public string PontuacaoCorretaDivsXPath { get; init; }
    public string DuplaXPath { get; init; }
    public string NumeroTotalGolsXPath { get; init; }
    public string NomeTimesClass { get; init; }
    public string PartidaIniciadaXPath { get; init; }
    public string AoVivoDescriptionCopaMundoXPath { get; init; }
    public string AoVivoDescriptionClubesXPath { get; init; }
    public string NoContentXPath { get; init; }
    public string ResultadosClubes { get; init; }
    public string ResultadosWorldcup { get; init; }
    public string ResultItemClass { get; init; }
    public string ResultItemHeaderClass { get; init; }
}
