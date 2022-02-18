namespace CommonDatabase.Entities;

public partial record RankingMarket
{
    public int Id { get; set; }
    public string Market { get; set; } = null!;
}