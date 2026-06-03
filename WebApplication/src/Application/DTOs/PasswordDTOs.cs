using System.ComponentModel.DataAnnotations;

public class RequestPasswordDtos
{

    [Required]
    public string Password {get;  set;} 
    [Required]
    public string ConfirmPassword {get;  set;} 
}