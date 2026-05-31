public class AuthPassword
{
    public IPasswordHasher _passwordHasher; 
    public readonly GetPassword _getPassword;
    

    public AuthPassword(IPasswordHasher passwordHasher, GetPassword getPassword)
    {

        _passwordHasher = passwordHasher; 
        _getPassword = getPassword;
    }

   public async Task<bool> Execute (string passwordKey, Guid id)
    {

        if(string.IsNullOrWhiteSpace(passwordKey))
        throw new Exception("Passwords not found");

        var dataSecurity = await _getPassword.Execute(id); 
        return _passwordHasher.Verify(
            passwordKey,
            dataSecurity.Hash
        );
    }
}