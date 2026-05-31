public class DeletePassword
{
    public readonly ICrudRepository<DataSecurity> _crudRepository;

    public DeletePassword (ICrudRepository <DataSecurity> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task Execute(Guid id )
    {  
        var password = await _crudRepository.GetByIdAsync(id); 

        if(password == null)
        throw new Exception ("Password not found");

        await _crudRepository.DeleteAsync(password);

    } 

}