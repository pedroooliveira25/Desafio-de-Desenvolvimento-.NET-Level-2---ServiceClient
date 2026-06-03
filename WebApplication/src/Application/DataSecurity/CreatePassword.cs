public class CreatePassword
{
    private readonly ICrudRepository<DataSecurity> _crudRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreatePassword(ICrudRepository<DataSecurity> crudRepository, IPasswordHasher passwordHasher)
    {
        _crudRepository = crudRepository;
        _passwordHasher = passwordHasher; 
    }

    public async Task<DataSecurity> Execute (RequestPasswordDtos requestPasswordDtos)
    {
        if(requestPasswordDtos.Password != requestPasswordDtos.ConfirmPassword)
        throw new Exception("Passwords do not match");

       if (string.IsNullOrWhiteSpace(requestPasswordDtos.Password))
        {
            throw new Exception("Password cannot be empty or space");
        }

        var hash = _passwordHasher.Hash(requestPasswordDtos.Password);
       
        var password = new DataSecurity(
            requestPasswordDtos.Password,
            requestPasswordDtos.ConfirmPassword,
            hash
           
        ); 

        await _crudRepository.AddAsync(password);
        return password; 
    }
}

