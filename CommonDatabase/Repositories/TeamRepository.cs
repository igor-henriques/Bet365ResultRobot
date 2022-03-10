namespace CommonDatabase.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly Bet365RobotContext context;

    public TeamRepository(Bet365RobotContext context)
    {
        this.context = context;
    }

    public async Task<Team> GetByNameAsync(string teamName)
    {
        return await context.Teams.FirstOrDefaultAsync(x => x.Nome.Equals(teamName));
    }
}