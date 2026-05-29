using System.ComponentModel.DataAnnotations.Schema;

public class DataSecurity : Notification
{   
    [Column("Id")]
    public Guid Id {get; set;} 
    [Column("Password")]
    public string Password{get; set;}
    public string ConfirmPassword{get; set;}
    public DataSecurity(string passwordKey, string confirmPassword, Guid id)
    {

        ValidateInfo(passwordKey, confirmPassword, id);

        Id = id;
        Password = passwordKey;
        ConfirmPassword = confirmPassword; 
    }


    public void ValidateInfo(string passwordKey, string confirmPassword, Guid id)
    {
        ValidatePropertiesString(passwordKey, "Password");
        ValidatePropertiesString(confirmPassword, "Confirm");
        ValidatePropertiesGuidId(id, "Id");
    }

     public void Update(string passwordKey, string confirmPassword, Guid id)
    {

        if (!ValidatePropertiesString(passwordKey, "Password"))
            throw new Exception("Invalid password");

        if (!ValidatePropertiesString(confirmPassword, "Confirm"))
            throw new Exception("Password is diferent");

        if (!ValidatePropertiesGuidId(id, "Id"))
            throw new Exception("Invalid id");
        
    }
}