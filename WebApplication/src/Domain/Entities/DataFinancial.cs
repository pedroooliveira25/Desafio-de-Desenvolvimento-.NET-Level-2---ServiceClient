
using System.ComponentModel.DataAnnotations.Schema;
public class FinancialData : Notification
{
    [Column("Finance")]
    public decimal Finance { get; set; }
    [Column("Patrimony")]
    public decimal Patrimony { get; set; }


    public FinancialData(decimal finance, decimal patrimony)
    {
        ValidateInfo(finance, patrimony);

        Finance = finance;
        Patrimony = patrimony;
    }



//Criar Validações

    public void ValidateInfo(decimal finance, decimal patrimony)
    {
        ValidatePropertiesDecimal(finance, "Finance");
        ValidatePropertiesDecimal(patrimony, "Patrimony");

        if (finance + patrimony <= 1000)
        {
            throw new Exception("Your finance is invalid");
        }
    }

    public void Update(decimal finance, decimal patrimony)
    { 

        if (!ValidatePropertiesDecimal(finance, "Finance"))
            throw new Exception("Invalid value");

        if (!ValidatePropertiesDecimal(patrimony, "Patrimony"))
            throw new Exception("Invalid patrimony");
    }
}

