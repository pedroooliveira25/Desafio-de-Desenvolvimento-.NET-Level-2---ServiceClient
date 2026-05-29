public class CreatePassword
{
    public readonly ICrudRepository<SecurityData> _crudRepository;
    public readonly IPasswordHasher _passwordHasher;

    public CreatePassword(ICrudRepository<SecurityData> crudRepository, IPasswordHasher passwordHasher)
    {
        _crudRepository = crudRepository;
        _passwordHasher = passwordHasher; 
    }

    public async Task<SecurityData> Execute (string passwordKey, string confirmPassword)
    {
        IPasswordHasher service = new PasswordHasher(); 

        var hash = service.Hash(passwordKey);
        var isVerify = service.Verify(passwordKey, hash);

        if(!isVerify)
        throw new Exception("Invalid password");

        var password = new SecurityData(
            passwordKey,
            confirmPassword
        ); 

        await _crudRepository.AddAsync();
        return password; 
    }
}

