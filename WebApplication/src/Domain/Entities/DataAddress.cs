public class DataAddress
{
    private string Road {get; set;}
    private int Number {get; set;}
    private string District {get; set;}
    private string City {get; set;}
    private string Stage {get; set;}
    private string Cep {get; set;}



    public DataAddress(string road, int number, string district, string city, string stage, string cep )
    {
        
        


        this.Road = road;
        this.Number = number;
        this.District = district;
        this.City = city;
        this.Stage = cep;
    }
}