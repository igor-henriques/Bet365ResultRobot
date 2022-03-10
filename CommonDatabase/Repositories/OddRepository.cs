namespace CommonDatabase.Repositories;

public class OddRepository : IOddRepository
{
    private readonly Bet365RobotContext context;

    public OddRepository(Bet365RobotContext context)
    {
        this.context = context;
    }

    public async Task<Odd> InsertAsync(Odd odd)
    {
        context.Add(odd);
        await SaveChangesAsync();

        return odd;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}