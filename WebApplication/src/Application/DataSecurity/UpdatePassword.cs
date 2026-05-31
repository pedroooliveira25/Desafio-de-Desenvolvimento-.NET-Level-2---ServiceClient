public class UpdatePassword
{
    private readonly ICrudRepository<DataSecurity> _crudRepository;

    public UpdatePassword(ICrudRepository<DataSecurity> crudRepository)
    {
        _crudRepository = crudRepository;
    }

    public async Task<DataSecurity> Execute(Guid id, string hash)
    {
        var dataSecurity = await _crudRepository.GetByIdAsync(id);

        if (dataSecurity == null)
            throw new Exception("DataSecurity not found");

        dataSecurity.Hash = hash;

        await _crudRepository.UpdateAsync(dataSecurity);

        return dataSecurity;
    }
}