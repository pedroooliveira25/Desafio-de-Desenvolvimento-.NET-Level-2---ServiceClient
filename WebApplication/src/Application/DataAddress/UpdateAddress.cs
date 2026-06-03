public class UpdateDateAddress
{
    public readonly ICrudRepository<DataAddress> _crudRepository;

      public UpdateDateAddress(ICrudRepository <DataAddress> crudRepository)
    {
        _crudRepository = crudRepository;
    }


    public async Task<DataAddress> Execute(string road, string district, string city, string stage, int cep, int number, Guid id)
    {
        var dataAddress = await _crudRepository.GetByIdAsync(id);

        if (dataAddress == null)
            throw new Exception("Data financial not found");

      dataAddress.Road = road;
      dataAddress.District = district;
      dataAddress.City = city;
      dataAddress.Stage = stage;
      dataAddress.Cep = cep;
      dataAddress.Id = id;

        await _crudRepository.UpdateAsync(dataAddress);

        return dataAddress;
    }
}