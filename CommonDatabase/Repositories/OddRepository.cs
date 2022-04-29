namespace CommonDatabase.Repositories;

public class OddRepository : IOddRepository
{
    private readonly BetfairDataContext dataContext;

    public OddRepository(BetfairDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async ValueTask<Odd> AddAsync(Odd odd)
    {
        if (odd.Id != default(long))
            return null;
                
        if (!await DataAlreadyExists(odd))
        {
            dataContext.Odd.Add(odd);

            await dataContext.SaveChangesAsync();

            return odd;
        }        

        return null;
    }

    public async ValueTask<bool> DataAlreadyExists(Odd odd)
    {
        var dataAlreadyExists = await dataContext.Odd
            .Where(o =>
                o.DataInicio == odd.DataInicio &
                o.NomeTimeCasa == odd.NomeTimeCasa &
                o.NomeTimeVisitante == odd.NomeTimeVisitante &
                o.ProbabilidadeEmpate == odd.ProbabilidadeEmpate &
                o.ProbabilidadeVitoriaTimeVisitante == odd.ProbabilidadeVitoriaTimeVisitante &
                o.ProbabilidadeVitoriaTimeCasa == odd.ProbabilidadeVitoriaTimeCasa)
            .AnyAsync();

        return dataAlreadyExists;
    }
}
