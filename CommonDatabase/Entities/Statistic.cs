namespace CommonDatabase.Entities;

public partial record Statistic
{
    public Statistic()
    {
        StatisticMaximas = new HashSet<StatisticMaxima>();
    }

    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public string? Categoria { get; set; }
    public string? Template { get; set; }
    public string? IdTelegramGroups { get; set; }
    public string? IdTelegramGroupsTodosCampeonatos { get; set; }

    public virtual ICollection<StatisticMaxima> StatisticMaximas { get; set; }
}