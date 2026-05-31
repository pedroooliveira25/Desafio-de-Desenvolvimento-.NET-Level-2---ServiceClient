using System.ComponentModel.DataAnnotations;

public class DataAddressDTOs

{
    [Required]
    public string Road { get; private set; }
    [Required]
    public string District { get; private set; }
    [Required]
    public string City { get; private set; }
    [Required]
    public string Stage { get; private set; }
    [Required]
    public int Cep { get; private set; }

}



