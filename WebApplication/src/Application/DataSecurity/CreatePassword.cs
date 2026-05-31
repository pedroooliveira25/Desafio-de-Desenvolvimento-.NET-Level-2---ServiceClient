public class CreatePassword
{
    private readonly ICrudRepository<DataSecurity> _crudRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreatePassword(ICrudRepository<DataSecurity> crudRepository, IPasswordHasher passwordHasher)
    {
        _crudRepository = crudRepository;
        _passwordHasher = passwordHasher; 
    }

    public async Task<DataSecurity> Execute (string passwordKey, string confirmPassword, Guid id)
    {
        if(passwordKey != confirmPassword)
        throw new Exception("Passwords do not match");

        var hash = _passwordHasher.Hash(passwordKey);
       
        var password = new DataSecurity(
            hash,
            passwordKey,
            id,
            confirmPassword
           
        ); 

        await _crudRepository.AddAsync(password);
        return password; 
    }
}

