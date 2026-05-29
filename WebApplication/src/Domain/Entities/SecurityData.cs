public class SecurityData : Notification
{
    public string Password{get; set;}
    public string ConfirmPassword{get; set;}

    public SecurityData(string passwordKey, string confirmPassword)
    {

        ValidatePropertiesString(passwordKey, "Password");
        ValidatePropertiesString(confirmPassword, "Confirm");

        Password = passwordKey;
        ConfirmPassword = confirmPassword; 
    }

    //class para criar senhas, porém eu tenho que transformar
    //essa senha em um Hash é armazenar apenas o hash para criar comparação

    
 
     public void Update(string passwordKey, string confirmPassword)
    {

        if (!ValidatePropertiesString(passwordKey, "Password"))
            throw new Exception("Invalid password");

        if (!ValidatePropertiesString(confirmPassword, "Confirm"))
            throw new Exception("Password is diferent");

    }
}