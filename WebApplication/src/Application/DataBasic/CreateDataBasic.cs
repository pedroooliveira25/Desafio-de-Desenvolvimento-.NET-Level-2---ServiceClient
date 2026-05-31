public class CreateDataBasic
{
    private readonly ICrudRepository<DataBasic> _crudRepository;

    public CreateDataBasic(ICrudRepository<DataBasic> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataBasic> Execute (string name, DateTime dateOfBirth, string cpf, string email, string phone, Guid id)
    {
       
        var dataBasic = new DataBasic(
           name,
           dateOfBirth,
           cpf,
           email,
           phone,
           id
           
        ); 
        
        await _crudRepository.AddAsync(dataBasic);
        return dataBasic;
    }
}

