namespace CommonDatabase.Repositories;

public class MatchRepository
{
    private readonly Bet365RobotContext context;
    private readonly ILogger<MatchRepository> logger;

    public MatchRepository(Bet365RobotContext context, ILogger<MatchRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<Match> GetMatchAsync(string title, DateTime date)
    {
        return await context.Matches.FirstOrDefaultAsync(x => x.Title == title && x.Date == date);
    }

    //Insert Match into database
    public async Task Insert(Match match)
    {
        if (!context.Matches.Any(x => x.Title == match.Title && x.Date == match.Date))
        {
            context.Matches.Add(match);
            await SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}