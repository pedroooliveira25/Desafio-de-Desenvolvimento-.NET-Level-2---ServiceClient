using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class DataAddressDTOs

{
    [Required]
    public string Road { get;  set; }
    [Required]
    public string District { get;  set; }
    [Required]
    public string City { get;  set; }
    [Required]
    public string Stage { get;  set; }
    [Required]
    public int Cep { get;  set; }
    [Required]
    public int Number { get;  set; }
    [Required]
    [BsonId]
    [BsonRepresentation(BsonType.String)]
     public Guid Id { get;  set; }

}



