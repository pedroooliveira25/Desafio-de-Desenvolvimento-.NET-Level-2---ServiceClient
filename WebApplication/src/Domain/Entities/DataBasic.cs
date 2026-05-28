using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Net.Mail;
public class DataBasic : Notification
{
    [Column("Name")]
    public string Name { get; set; }

    [Column("Date of birth ")]
    public DateTime DateOfBirth { get; set; }

    [Column("CPF")]
    public string Cpf { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    [Column("Phone")]
    public string Phone { get; set; }


    public DataBasic(string name, DateTime dateOfBirth, string cpf, string email, string phone)
    {
        ValidateInfo(name, dateOfBirth, cpf, email, phone);

        Name = name;
        DateOfBirth = dateOfBirth;
        Cpf = cpf;
        Email = email;
        Phone = phone;
    }

    public void ValidateInfo(string name, DateTime dateOfBirth, string cpf, string email, string phone)
    {
        ValidateNumber(phone);
        ValidatePropertiesString(name, "name");
        IsValidEmail(email);
        ValidationBirth(dateOfBirth);
        ValidateCpf(cpf);
    }

    public bool ValidateNumber(string phone)
    {
        if (!ValidatePropertiesString(phone, "phone") || phone.Length == 11)
        {
         return false;
        }
        return true;    
    } 

    public bool IsValidEmail(string email)
    {
        if (!ValidatePropertiesString(email, "email"))
            return false;
        try
        {
            var mail = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false; 
        }
    }
    public bool ValidationBirth(DateTime dateOfBirth)
    {
        
        
        ValidatePropertiesDate(dateOfBirth, "date of birth");

        DateTime maioridade = DateTime.Today.AddDays(-18);
        if (dateOfBirth <= maioridade)
        {
           return false;
        }
        return true;
    }
    public void ValidateCpf(string cpf)
    {   
        ValidatePropertiesString(cpf, "cpf");

        if(cpf.Length > 11)
        {
            throw new Exception("Cpf invalide");  
        } 
    }

    public void Update(string name, DateTime dateOfBirth, string cpf, string email, string phone)
    {
        if (!ValidatePropertiesString(cpf, "cpf"))
            throw new Exception("Invalid cpf"); 

        if (!ValidatePropertiesString(phone, "phone"))
            throw new Exception("Invalid phone");

        if (!ValidatePropertiesString(name, "name"))
            throw new Exception("Invalid name");

        if (!ValidatePropertiesString(email, "email"))
            throw new Exception("Invalid email");

        if (!ValidatePropertiesDate(dateOfBirth, "date of birth"))
            throw new Exception("Invalid birth");

        Name = name;
        DateOfBirth = dateOfBirth;
        Cpf = cpf;
        Email = email;
        Phone = phone;
    }
}