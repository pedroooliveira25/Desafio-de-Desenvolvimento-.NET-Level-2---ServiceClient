using System.ComponentModel.DataAnnotations;

public class DataBasicDTOs

{
    [Required]
    public string Name { get; private set; }
    [Required]
    public DateTime DataOfBith { get; private set; }
    [Required]
    public string Cpf { get; private set; }
    [Required]
    public string Email { get; private set; }
    [Required]
    public string Phone { get; private set; }

}
