using System.ComponentModel.DataAnnotations;

public class RequestPasswordDtos
{

    [Required]
    public string Password {get; private set;} 
    [Required]
    public string ConfirmPassword {get; private set;} 
}