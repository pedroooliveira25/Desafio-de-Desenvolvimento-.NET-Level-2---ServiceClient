using System.ComponentModel.DataAnnotations;

public class DataFinancialDTOs
{
    [Required]
    private decimal Finance { get; set; }
    [Required]
    private decimal Patrimony { get; set; }

}
   
