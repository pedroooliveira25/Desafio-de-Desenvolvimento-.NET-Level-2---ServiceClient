using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class RabbitPublisher
{
    public void PublishCadastroEmail(string nome, string email)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "cadastro.em.analise.email",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var message = new CadastroEmailMessage
        {
            Nome = nome,
            Email = email
        };

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: "",
            routingKey: "cadastro.em.analise.email",
            basicProperties: null,
            body: body
        );
    }
}