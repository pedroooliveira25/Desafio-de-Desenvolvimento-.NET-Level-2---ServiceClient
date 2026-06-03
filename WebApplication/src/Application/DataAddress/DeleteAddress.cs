public class DeleteAddress
{
    private readonly ICrudRepository<DataAddress> _crudRepository;

    public DeleteAddress(ICrudRepository<DataAddress> crudRepository)
    {
        _crudRepository = crudRepository;
    }

       public async Task Execute(Guid id )
    {  
        var dataAddress = await _crudRepository.GetByIdAsync(id); 

        if(dataAddress == null)
        throw new Exception ("Address not found");

        await _crudRepository.DeleteAsync(id);

    } 
}