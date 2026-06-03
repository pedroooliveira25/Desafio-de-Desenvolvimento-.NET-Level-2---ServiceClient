using System.ComponentModel.DataAnnotations;

public class DataBasicDTOs

{
    [Required]
    public string Name { get;  set; }
    [Required]
    public DateTime DateOfBith { get; set; }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    public Guid Id { get; set; }
    

}
