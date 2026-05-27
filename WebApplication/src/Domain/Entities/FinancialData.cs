
using System.ComponentModel.DataAnnotations.Schema;
public class FinancialData : Notification
{
    [Column("Finance")]
    public int Finance {get; set;}
    [Column("Patrimony")]
    public int Patrimony {get; set;}


    public FinancialData(int finance, int patrimony)
    {
        ValidatePropertiesInt(finance, "Finance");
        ValidatePropertiesInt(patrimony, "patrimony");

        Finance = finance;
        Patrimony = patrimony;
    }

     public void Update(int finance, int patrimony)
    {

        if (!ValidatePropertiesInt(finance, "Finance"))
            throw new Exception("Invalid value");

        if (!ValidatePropertiesInt(patrimony, "Patrimony"))
            throw new Exception("Invalid patrimony");

    }
}

