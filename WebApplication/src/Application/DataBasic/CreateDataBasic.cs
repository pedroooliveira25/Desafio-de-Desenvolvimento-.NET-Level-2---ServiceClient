public class CreateDataBasic
{
    private readonly ICrudRepository<DataBasic> _crudRepository;

    public CreateDataBasic(ICrudRepository<DataBasic> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataBasic> Execute (DataBasicDTOs request)
    {
       
        var dataBasic = new DataBasic(
           request.Name,
           request.DateOfBith,
           request.Cpf,
           request.Email,
           request.Phone,
           Guid.NewGuid()
        ); 
        
        await _crudRepository.AddAsync(dataBasic);
        return dataBasic;
    }
}

