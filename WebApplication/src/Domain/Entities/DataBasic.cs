using System.ComponentModel.DataAnnotations.Schema;
public class DataBasic : Notification
{
    [Column("Name")]
    public string Name {get; set;}

    [Column("Date of birth ")]
    public DateTime DateOfBirth {get; set;}

    [Column("CPF")]
    public int Cpf {get; set;}

    [Column("Email")]
    public string Email {get; set;}

    [Column("Phone")]
    public int Phone {get; set;}


    public DataBasic(string name, DateTime dateOfBirth, int cpf, string email, int phone)
    {

        ValidatePropertiesInt(cpf, "cpf");
        ValidatePropertiesInt(phone, "phone");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(email, "email");
        ValidatePropertiesDateOfBirth(dateOfBirth, "date of birth");
    
        Name = name;
        DateOfBirth = dateOfBirth;
        Cpf = cpf;
        Email = email;
        Phone = phone;
        
    }

    public void Update (string name, DateTime dateOfBirth, int cpf, string email, int phone)
    {
        
        if(!ValidatePropertiesInt(cpf, "cpf"))
        throw new Exception("Invalid cpf");

        if(!ValidatePropertiesInt(phone, "phone"))
        throw new Exception("Invalid phone");

        if(!ValidatePropertiesString(name, "name"))
        throw new Exception("Invalid name");

        if(!ValidatePropertiesString(email, "email"))
        throw new Exception("Invalid email");

        if(!ValidatePropertiesDateOfBirth(dateOfBirth, "date of birth"))
        throw new Exception("Invalid birth");
        
        Name = name;
        DateOfBirth = dateOfBirth;
        Cpf = cpf;
        Email = email;
        Phone = phone;
    }
}