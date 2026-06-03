public class GetDataBasic
{
    public readonly ICrudRepository<DataBasic> _crudRepository;

      public GetDataBasic(ICrudRepository <DataBasic> crudRepository)
    {
        _crudRepository = crudRepository;
    }

     public async Task<DataBasic> Execute(Guid id)
    {
        var dataBasic = await _crudRepository.GetByIdAsync(id);

        if (dataBasic == null)
            throw new Exception("Data basic not found");

        return dataBasic;
    }
}