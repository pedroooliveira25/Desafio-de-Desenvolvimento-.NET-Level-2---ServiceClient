public class CreateFinancial
{
    private readonly ICrudRepository<DataFinancial> _crudRepository;

    public CreateFinancial(ICrudRepository<DataFinancial> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataFinancial> Execute (DataFinancialDTOs request)
    {
       
        var financial = new DataFinancial(
        request.Finance,
        request.Patrimony,
        request.Id
    ); 
        
        await _crudRepository.AddAsync(financial);
        return financial;
    }
}

