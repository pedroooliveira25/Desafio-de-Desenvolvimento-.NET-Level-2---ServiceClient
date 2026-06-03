
using System.ComponentModel.DataAnnotations;

public class ViaCepDTOs
{
    [Required]
    private string? Cep { get; set; }
    [Required]
    private string? Address { get; set; }
    [Required]
    private string? Apartment { get; set; }
    [Required]
    private string? Location { get; set; }
    [Required]
    private string? District { get; set; }
    [Required]
    private string? State { get; set; }

}
   

  


