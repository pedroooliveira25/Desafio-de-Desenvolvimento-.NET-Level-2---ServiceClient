public interface IPasswordHasher
{
     Guid id(); 
     string Hash(string password);
     bool Verify(string password, string hash);
    
}