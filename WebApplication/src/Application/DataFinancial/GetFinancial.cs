public class GetFinancial
{
    public readonly ICrudRepository<DataFinancial> _crudRepository;

      public GetFinancial(ICrudRepository <DataFinancial> crudRepository)
    {
        _crudRepository = crudRepository;
    }

     public async Task<DataFinancial> Execute(Guid id)
    {
        var dataFinancial = await _crudRepository.GetByIdAsync(id);

        if (dataFinancial == null)
            throw new Exception("Data financial not found");

        return dataFinancial;
    }
}