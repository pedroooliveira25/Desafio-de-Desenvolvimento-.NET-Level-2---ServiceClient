public class UpdateFinancial
{
    public readonly ICrudRepository<DataFinancial> _crudRepository;

      public UpdateFinancial(ICrudRepository <DataFinancial> crudRepository)
    {
        _crudRepository = crudRepository;
    }


    public async Task<DataFinancial> Execute(decimal finance, decimal patrimony, Guid id)
    {
        var dataFinancial = await _crudRepository.GetByIdAsync(id);

        if (dataFinancial == null)
            throw new Exception("Data financial not found");

        dataFinancial.Finance = finance;
        dataFinancial.Patrimony = patrimony;

        await _crudRepository.UpdateAsync(dataFinancial);

        return dataFinancial;
    }
}