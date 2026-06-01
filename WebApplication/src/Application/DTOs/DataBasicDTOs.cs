using System.ComponentModel.DataAnnotations;

public class DataBasicDTOs

{
    [Required]
    public string Name { get; private set; }
    [Required]
    public DateTime DateOfBith { get; private set; }
    [Required]
    public string Cpf { get; private set; }
    [Required]
    public string Email { get; private set; }
    [Required]
    public string Phone { get; private set; }
    public Guid Id { get; private set; }
    

}
