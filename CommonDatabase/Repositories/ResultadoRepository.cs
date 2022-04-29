namespace CommonDatabase.Repositories;

public class ResultadoRepository : IResultadoRepository
{
    private readonly BetfairDataContext dataContext;

    public ResultadoRepository(BetfairDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async ValueTask<Resultado> AddAsync(Resultado resultado)
    {
        if (resultado.Id != default(long))
            return null;

        if (!await DataAlreadyExists(resultado))
        {
            dataContext.Resultado.Add(resultado);

            await dataContext.SaveChangesAsync();

            return resultado;
        }

        return null;
    }

    public async ValueTask<bool> DataAlreadyExists(Resultado resultado)
    {
        var dataAlreadyExists = await dataContext.Resultado
            .Where(o =>
                o.Horario == resultado.Horario &
                o.NomeTimeCasa == resultado.NomeTimeCasa &
                o.NomeTimeVisitante == resultado.NomeTimeVisitante &
                o.TotalGols == resultado.TotalGols)
            .AnyAsync();

        return dataAlreadyExists;
    }
}
