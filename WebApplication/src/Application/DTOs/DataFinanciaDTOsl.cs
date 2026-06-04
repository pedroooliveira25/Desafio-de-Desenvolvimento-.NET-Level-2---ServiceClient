using System.ComponentModel.DataAnnotations;

public class DataFinancialDTOs
{
    [Required]
    public decimal Finance { get; set; }
    [Required]
    public decimal Patrimony { get; set; }
    [Required]
    public  Guid Id { get; set; }

}
   
