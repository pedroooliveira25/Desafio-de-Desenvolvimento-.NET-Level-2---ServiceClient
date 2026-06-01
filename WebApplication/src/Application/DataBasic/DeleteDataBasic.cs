public class DeleteDataBasic
{
    private readonly ICrudRepository<DataBasic> _crudRepository;

    public DeleteDataBasic(ICrudRepository<DataBasic> crudRepository)
    {
        _crudRepository = crudRepository;
    }

       public async Task Execute(Guid id )
    {  
        var dataBasic = await _crudRepository.GetByIdAsync(id); 

        if(dataBasic == null)
        throw new Exception ("Date basic not found");

        await _crudRepository.DeleteAsync(id);

    } 
}