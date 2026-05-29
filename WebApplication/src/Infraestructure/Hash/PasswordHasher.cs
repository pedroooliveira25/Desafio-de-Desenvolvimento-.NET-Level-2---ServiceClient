
public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        
    }
    bool Verify(string password, string hash)
    {
        
    }

    bool IPasswordHasher.Verify(string password, string hash)
    {
        return Verify(password, hash);
    }
}