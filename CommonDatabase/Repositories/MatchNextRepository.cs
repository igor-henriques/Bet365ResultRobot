namespace CommonDatabase.Repositories;

public class MatchNextRepository : IMatchNextRepository
{
    private readonly Bet365RobotContext context;
    private readonly ILogger<MatchRepository> logger;

    public MatchNextRepository(Bet365RobotContext context, ILogger<MatchRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    //Insert Match into database
    public async Task<MatchNext> InsertAsync(MatchNext match)
    {
        if (!await context.MatchNexts.AnyAsync(x =>
        x.Date == match.Date
        && x.IdCompetition == match.Id
        && x.IdTeamAway == match.IdTeamAway
        && x.IdTeamHome == match.IdTeamHome
        && x.Tempo == match.Tempo))
        {
            context.MatchNexts.Add(match);
            await SaveChangesAsync();
        }

        return match;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}