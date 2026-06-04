
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class DataFinancial : Notification
{
    [Column("Finance")]
    public decimal Finance { get; set; }
    [Column("Patrimony")]
    public decimal Patrimony { get; set; }
    [Column("Id")]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public DataFinancial(decimal finance, decimal patrimony, Guid id)
    {
        ValidateInfo(finance, patrimony, id);

        Finance = finance;
        Patrimony = patrimony;
        Id = id;
    }


    public void ValidateInfo(decimal finance, decimal patrimony, Guid id)
    {
        ValidatePropertiesDecimal(finance, "Finance");
        ValidatePropertiesDecimal(patrimony, "Patrimony");
        ValidatePropertiesGuidId(id, "Id");

        if (finance + patrimony <= 1000)
        {
            throw new Exception("Your finance is invalid");
        }
    }

    public void Update(decimal finance, decimal patrimony, Guid id)
    {

        if (!ValidatePropertiesDecimal(finance, "Finance"))
            throw new Exception("Invalid value");

        if (!ValidatePropertiesDecimal(patrimony, "Patrimony"))
            throw new Exception("Invalid patrimony");

        if (!ValidatePropertiesGuidId(id, "Id"))
            throw new Exception("Invalid id");
    }
}

