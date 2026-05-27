using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Notification
{
    public Notification()
    {
        NotificationsList = new List<Notification>();
    }

    [JsonIgnore]    
    [NotMapped]
    public string? PropertyName{ get; set; }

    [JsonIgnore]
    [NotMapped]

    public string? Message { get; set; }

    public List<Notification> NotificationsList {get; private set;}

    public void Notify(string message, string propertyName)
    {
        NotificationsList.Add(new Notification
        {
            Message = message, 
            PropertyName = propertyName
        }); 
    }
    

    public bool ValidatePropertiesString(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            NotificationsList.Add(new Notification
            {
                Message = "Erro", 
                PropertyName = "Erro"
            });
            return false;
        }
        return true; 
    }

     public bool ValidatePropertiesInt(int value, string propertyName)
    {
        if (value <= 0)
        {
            NotificationsList.Add(new Notification
            {
                Message = "Erro", 
                PropertyName = "Erro"
            });
            return false;
        }
        return true;
    }

         public bool ValidatePropertiesDate(DateTime value, string propertyName)
    {

        if (value <= DateTime.MinValue)
        {
            NotificationsList.Add(new Notification
            {
                Message = "Access denied -18", 
                PropertyName = "value"
            });
            return false;
        }
        return true; 
    }


    


}