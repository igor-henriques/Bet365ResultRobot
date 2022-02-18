namespace CommonDatabase.Entities;

public partial record Ranking
{
    public Guid Id { get; set; }
    public DateTime DateUpdate { get; set; }
    public int IdCompetition { get; set; }
    public int IdTeam { get; set; }
    public string Team { get; set; } = null!;
    public string Market { get; set; } = null!;
    public int Position { get; set; }
    public int MatchesInPeriod { get; set; }
    public int MatchesInMarket { get; set; }
    public decimal MarketPercents { get; set; }
}
