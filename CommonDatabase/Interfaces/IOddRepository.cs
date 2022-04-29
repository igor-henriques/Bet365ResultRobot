
namespace CommonDatabase.Interfaces;

public interface IOddRepository
{
    ValueTask<Odd> AddAsync(Odd odd);
}
