
namespace CommonDatabase.Interfaces;

public interface IResultadoRepository
{
    ValueTask<Resultado> AddAsync(Resultado resultado);
}
