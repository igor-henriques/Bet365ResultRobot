namespace CommonDatabase.Interfaces;

public interface IOddRepository
{
    Task<Odd> InsertAsync(Odd odd);
    Task SaveChangesAsync();
}