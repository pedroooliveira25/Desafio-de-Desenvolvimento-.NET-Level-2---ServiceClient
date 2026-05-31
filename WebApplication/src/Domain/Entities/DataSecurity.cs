using System.ComponentModel.DataAnnotations.Schema;

public class DataSecurity : Notification
{   
    [Column("Id")]
    public Guid Id {get; set;} 
    [Column("Password")]
    public string Password{get; set;}
    public string ConfirmPassword{get; set;}
    [Column("Hash")]
    public string Hash {get; set;}
    public DataSecurity(string passwordKey, string confirmPassword, Guid id, string hash)
    {

        ValidateInfo(passwordKey, confirmPassword, id, hash);

        Id = id;
        Password = passwordKey;
        ConfirmPassword = confirmPassword; 
    }


    public void ValidateInfo(string passwordKey, string confirmPassword, Guid id, string hash)
    {
        ValidatePropertiesString(passwordKey, "Password");
        ValidatePropertiesString(confirmPassword, "Confirm");
        ValidatePropertiesString(hash, "Hash");
        ValidatePropertiesGuidId(id, "Id");
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