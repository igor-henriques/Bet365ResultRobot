namespace CommonDatabase.Entities;

public partial record MatchNext
{
    public long Id { get; set; }
    public long IdCompetition { get; set; }
    public bool IsStarted { get; set; }
    public string TimeCasa { get; set; } = null!;
    public string TimeVisitante { get; set; } = null!;
    public int? IdTeamHome { get; set; }
    public int? IdTeamAway { get; set; }
    public DateTime Date { get; set; }
    public DateTime UserDate { get; set; }
    public DateTime? DataInicioJogo { get; set; }
    public string Tempo { get; set; } = null!;
    public decimal OddCasa { get; set; }
    public decimal OddEmpate { get; set; }
    public decimal OddFora { get; set; }
    public decimal OddOver05 { get; set; }
    public decimal OddOver15 { get; set; }
    public decimal OddOver25 { get; set; }
    public decimal OddOver35 { get; set; }
    public decimal OddUnder05 { get; set; }
    public decimal OddUnder15 { get; set; }
    public decimal OddUnder25 { get; set; }
    public decimal OddUnder35 { get; set; }
    public decimal OddGols0 { get; set; }
    public decimal OddGols1 { get; set; }
    public decimal OddGols2 { get; set; }
    public decimal OddGols3 { get; set; }
    public decimal OddGols4 { get; set; }
    public decimal OddBttsS { get; set; }
    public decimal OddBttsN { get; set; }
    public decimal OddCasaMarcaS { get; set; }
    public decimal OddCasaMarcaN { get; set; }
    public decimal OddForaMarcaS { get; set; }
    public decimal OddForaMarcaN { get; set; }
    public bool SendTelegramConfrontos { get; set; }
}
