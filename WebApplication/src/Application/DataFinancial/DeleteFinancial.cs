public class DeleteFinancial
{
   public readonly ICrudRepository<DataFinancial> _crudRepository;

    public DeleteFinancial (ICrudRepository <DataFinancial> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task Execute(Guid id )
    {  
        var financial = await _crudRepository.GetByIdAsync(id); 

        if(financial == null)
        throw new Exception ("Date financial not found");

        await _crudRepository.DeleteAsync(financial);

    } 

}