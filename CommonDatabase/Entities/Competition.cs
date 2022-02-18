namespace CommonDatabase.Entities;

public partial record Competition
{
    public Competition()
    {
        StatisticMaximas = new HashSet<StatisticMaxima>();
    }

    public int Id { get; set; }
    public int IdSport { get; set; }
    public string Descricao { get; set; } = null!;
    public string DescricaoAlternativa { get; set; } = null!;
    public string Img { get; set; } = null!;
    public DateTime LastUpdate { get; set; }
    public DateTime NextUpdate { get; set; }
    public int Ordem { get; set; }
    public DateTime DataUpdateMaximas { get; set; }

    public virtual ICollection<StatisticMaxima> StatisticMaximas { get; set; }
}