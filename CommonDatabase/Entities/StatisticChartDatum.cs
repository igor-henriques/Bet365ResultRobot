namespace CommonDatabase.Entities;

public partial record StatisticChartDatum
{
    public long Id { get; set; }
    public int IdCompetition { get; set; }
    public DateTime DataUpdate { get; set; }
    public decimal Over15 { get; set; }
    public decimal Under25 { get; set; }
    public decimal AmbasMarcam { get; set; }
    public decimal Over25 { get; set; }
}