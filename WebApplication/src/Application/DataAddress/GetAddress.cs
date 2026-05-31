public class GetAddress
{
    public readonly ICrudRepository<DataAddress> _crudRepository;

      public GetAddress(ICrudRepository <DataAddress> crudRepository)
    {
        _crudRepository = crudRepository;
    }

     public async Task<DataAddress> Execute(Guid id)
    {
        var dataAddress = await _crudRepository.GetByIdAsync(id);

        if (dataAddress == null)
            throw new Exception("Address not found");

        return dataAddress;
    }
}