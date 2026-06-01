public class CreateAddress
{
    private readonly ICrudRepository<DataAddress> _crudRepository;

    public CreateAddress(ICrudRepository<DataAddress> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataAddress> Execute (DataAddressDTOs request)
    {
       
        var dataAddress = new DataAddress(
           request.Road,
           request.District,
           request.City,
           request.Stage,
           request.Cep,
           request.Number,
           request.Id
        ); 
        
        await _crudRepository.AddAsync(dataAddress);
        return dataAddress;
    }
}

