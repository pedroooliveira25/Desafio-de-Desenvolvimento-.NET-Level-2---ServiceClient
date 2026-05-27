using System.ComponentModel.DataAnnotations.Schema;
public class DataAddress : Notification
{
    [Column("Road")]
    private string Road { get; set; }
    [Column("Number")]
    private int Number { get; set; }
    [Column("District")]
    private string District { get; set; }
    [Column("City")]
    private string City { get; set; }
    [Column("Stage")]
    private string Stage { get; set; }
    [Column("Cep")]
    private int Cep { get; set; }



    public DataAddress(string road, string district, string city, string stage, int cep, int number)
    {


        ValidatePropertiesString(road, "Road");
        ValidatePropertiesString(district, "District");
        ValidatePropertiesString(city, "City");
        ValidatePropertiesString(stage, "Stage");
        ValidatePropertiesInt(cep, "CEP");
        ValidatePropertiesInt(number, "Number");


        Road = road;
        Number = number;
        District = district;
        City = city;
        Stage = stage;
    }

    public void Update(string road, string district, string city, string stage, int cep, int number)
    {

        if (!ValidatePropertiesString(road, "Road"))
            throw new Exception("Invalid road");

        if (!ValidatePropertiesString(district, "District"))
            throw new Exception("Invalid district");

        if (!ValidatePropertiesString(city, "City"))
            throw new Exception("Invalid city");

        if (!ValidatePropertiesString(stage, "Stage"))
            throw new Exception("Invalid stage");

        if (!ValidatePropertiesInt(cep, "CEP"))
            throw new Exception("Invalid cep");

        Road = road;
        Number = number;
        District = district;
        City = city;
        Stage = stage;
    }
}