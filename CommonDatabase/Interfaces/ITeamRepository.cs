namespace CommonDatabase.Interfaces;

public interface ITeamRepository
{
    Task<Team> GetByNameAsync(string teamName);
}