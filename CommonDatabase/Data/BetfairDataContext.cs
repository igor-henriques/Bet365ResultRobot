namespace CommonDatabase.Data;

public partial class BetfairDataContext : DbContext
{
    public BetfairDataContext()
    {
    }

    public BetfairDataContext(DbContextOptions<BetfairDataContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Settings.ConnectionString);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Odd> Odd { get; set; }
    public DbSet<Resultado> Resultado { get; set; }
}