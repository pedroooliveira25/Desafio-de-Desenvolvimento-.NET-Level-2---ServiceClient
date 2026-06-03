public class GetPassword
{
    public readonly ICrudRepository<DataSecurity> _crudRepository;

      public GetPassword(ICrudRepository <DataSecurity> crudRepository)
    {
        _crudRepository = crudRepository;
    }

     public async Task<DataSecurity> Execute(Guid id)
    {
        var password = await _crudRepository.GetByIdAsync(id);

        if (password == null)
            throw new Exception("Password not found");

        return password;
    }
}