namespace CommonDatabase.Interfaces;

public interface IMatchNextRepository
{
    Task<MatchNext> InsertAsync(MatchNext match);
    Task SaveChangesAsync();
}