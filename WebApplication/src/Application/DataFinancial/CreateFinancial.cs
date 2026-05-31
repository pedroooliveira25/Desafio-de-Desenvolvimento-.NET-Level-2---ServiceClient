public class CreateFinancial
{
    private readonly ICrudRepository<DataFinancial> _crudRepository;

    public CreateFinancial(ICrudRepository<DataFinancial> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataFinancial> Execute (decimal finance, decimal patrimony, Guid id)
    {
       
        var financial = new DataFinancial(
           finance,
           patrimony,
           id
           
        ); 
        
        await _crudRepository.AddAsync(financial);
        return financial;
    }
}

