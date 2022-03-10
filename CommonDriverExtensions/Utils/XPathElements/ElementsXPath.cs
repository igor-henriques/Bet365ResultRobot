namespace CommonDriverExtensions.Utils.XPathElements;

[Serializable]
public class ElementsXPath
{
    [JsonProperty("VirtualFutebolURL")]
    public readonly string VirtualFutebolURL;

    [JsonProperty("ResultsTab")]
    public readonly string ResultsTab;

    [JsonProperty("ResultsTabShowMore")]
    public readonly string ResultsTabShowMore;

    [JsonProperty("RunningGameLabel")]
    public readonly string RunningGameLabel;

    [JsonProperty("CounterGameStop")]
    public readonly string CounterGameStop;

    [JsonProperty("NomeTimeCasa")]
    public readonly string NomeTimeCasa;

    [JsonProperty("PartidaVencedorCasa")]
    public readonly string PartidaVencedorCasa;

    [JsonProperty("PartidaVencedorEmpate")]
    public readonly string PartidaVencedorEmpate;

    [JsonProperty("PartidaVencedorVisitante")]
    public readonly string PartidaVencedorVisitante;

    [JsonProperty("NomeTimeVisitante")]
    public readonly string NomeTimeVisitante;

    [JsonProperty("DuplaHipoteseCasaOuEmpate")]
    public readonly string DuplaHipoteseCasaOuEmpate;

    [JsonProperty("DuplaHipoteseCasaOuVisitante")]
    public readonly string DuplaHipoteseCasaOuVisitante;

    [JsonProperty("DuplaHipoteseEmpateOuVisitante")]
    public readonly string DuplaHipoteseEmpateOuVisitante;

    [JsonProperty("EuroCup")]
    public readonly EurocupElements EurocupElements;

    [JsonProperty("Premiership")]
    public readonly PremiershipElements PremiershipElements;

    [JsonProperty("Superleague")]
    public readonly SuperleagueElements SuperleagueElements;

    [JsonProperty("WorldCup")]
    public readonly WorldcupElements WorldcupElements;

    [JsonProperty("Events")]
    public readonly Events Events;    
}