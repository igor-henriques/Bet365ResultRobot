namespace CommonDatabase.Entities;

public partial record StatisticMaxima
{
    public int Id { get; set; }
    public int IdCompetition { get; set; }
    public int IdStatistic { get; set; }
    public DateTime DataUpdate { get; set; }
    public int Atual { get; set; }
    public int Maxima { get; set; }
    public decimal Porcentagem { get; set; }
    public DateTime? DataEnvio { get; set; }
    public int? ValorEnvio { get; set; }
    public int? IdTelegramMessage { get; set; }
    public int? IdNextMatch { get; set; }
    public bool? IsGreen { get; set; }

    public virtual Competition IdCompetitionNavigation { get; set; } = null!;
    public virtual Statistic IdStatisticNavigation { get; set; } = null!;
}