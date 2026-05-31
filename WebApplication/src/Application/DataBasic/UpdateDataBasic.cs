public class UpdateDataBasic
{
    public readonly ICrudRepository<DataBasic> _crudRepository;

      public UpdateDataBasic(ICrudRepository <DataBasic> crudRepository)
    {
        _crudRepository = crudRepository;
    }


    public async Task<DataBasic> Execute(string name, DateTime dateOfBirth, string cpf, string email, string phone, Guid id)
    {
        var dataBasic = await _crudRepository.GetByIdAsync(id);

        if (dataBasic == null)
            throw new Exception("Data financial not found");

        dataBasic.Name = name;
        dataBasic.DateOfBirth = dateOfBirth;
        dataBasic.Cpf = cpf;
        dataBasic.Email = phone;
        dataBasic.Id = id;

        await _crudRepository.UpdateAsync(dataBasic);

        return dataBasic;
    }
}