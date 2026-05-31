public class CreateAddress
{
    private readonly ICrudRepository<DataAddress> _crudRepository;

    public CreateAddress(ICrudRepository<DataAddress> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataAddress> Execute (string road, string district, string city, string stage, int cep, int number, Guid id)
    {
       
        var dataAddress = new DataAddress(
           road,
           district,
           city,
           stage,
           cep,
           number,
           id 
        ); 
        
        await _crudRepository.AddAsync(dataAddress);
        return dataAddress;
    }
}

