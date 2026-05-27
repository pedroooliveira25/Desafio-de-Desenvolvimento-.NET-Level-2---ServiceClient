
using System.ComponentModel.DataAnnotations.Schema;
public class FinancialData : Notification
{
    [Column("Finance")]
    public int Finance { get; set; }
    [Column("Patrimony")]
    public int Patrimony { get; set; }


    public FinancialData(int finance, int patrimony)
    {
        ValidateInfo(finance, patrimony);

        Finance = finance;
        Patrimony = patrimony;
    }

    public void ValidateInfo(int finance, int patrimony)
    {
        ValidatePropertiesInt(finance, "Finance");
        ValidatePropertiesInt(patrimony, "Patrimony");

        if (finance + patrimony <= 1000)
        {
            throw new Exception("Your finance is invalid");
        }
    }

    public void Update(int finance, int patrimony)
    {

        if (!ValidatePropertiesInt(finance, "Finance"))
            throw new Exception("Invalid value");

        if (!ValidatePropertiesInt(patrimony, "Patrimony"))
            throw new Exception("Invalid patrimony");

    }


}

