public class CreatePassword
{
    public readonly ICrudRepository<DataSecurity> _crudRepository;
    public readonly IPasswordHasher _passwordHasher;

    public CreatePassword(ICrudRepository<DataSecurity> crudRepository, IPasswordHasher passwordHasher)
    {
        _crudRepository = crudRepository;
        _passwordHasher = passwordHasher; 
    }

    public async Task<DataSecurity> Execute (string passwordKey, string confirmPassword, Guid id)
    {


        var hash = _passwordHasher.Hash(passwordKey);
        var isVerify = _passwordHasher.Verify(passwordKey, hash);


        if(!isVerify)
        throw new Exception("Invalid password");

        var password = new DataSecurity(
            passwordKey,
            confirmPassword,
            id
        ); 

        await _crudRepository.AddAsync();
        return password; 
    }
}

