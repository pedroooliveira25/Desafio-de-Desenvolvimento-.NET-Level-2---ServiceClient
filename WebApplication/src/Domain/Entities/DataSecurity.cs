using System.ComponentModel.DataAnnotations.Schema;

public class DataSecurity : Notification
{   
    [Column("Id")]
    public Guid Id {get; set;} 
    [Column("Password")]
    public string PasswordKey{get; set;}
    public string ConfirmPassword{get; set;}
    [Column("Hash")]
    public string Hash {get; set;}
    public DataSecurity(string passwordKey, string confirmPassword, string hash)
    {

        ValidateInfo(passwordKey, confirmPassword, hash);

        Id = Guid.NewGuid();
        PasswordKey = passwordKey;
        ConfirmPassword = confirmPassword; 
    }


    public void ValidateInfo(string passwordKey, string confirmPassword, string hash)
    {
        ValidatePropertiesString(passwordKey, "Password");
        ValidatePropertiesString(confirmPassword, "Confirm");
        ValidatePropertiesString(hash, "Hash");
       
    }

     public void Update(string passwordKey, string confirmPassword, Guid id, string hash)
    {

        if (!ValidatePropertiesString(passwordKey, "Password"))
            throw new Exception("Invalid password");

         if (!ValidatePropertiesString(hash, "Hash"))
            throw new Exception("Invalid hash");

        if (!ValidatePropertiesString(confirmPassword, "Confirm"))
            throw new Exception("Password is diferent");

        if (!ValidatePropertiesGuidId(id, "Id"))
            throw new Exception("Invalid id");
        
    }
}