using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

public class RabbitConsumer
{
    private readonly EmailService _emailService;

    public RabbitConsumer(EmailService emailService)
    {
        _emailService = emailService;
    }

    public void Start()
    {
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq"
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "cadastro.em.analise.email",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (_, eventArgs) =>
        {
            var json = Encoding.UTF8.GetString(
                eventArgs.Body.ToArray()
            );

            var message =
                JsonSerializer.Deserialize<CadastroEmailMessage>(json);

            if (message != null)
            {
                await _emailService.SendCadastroEmAnalise(
                    message.Nome,
                    message.Email
                );
            }

            channel.BasicAck(
                eventArgs.DeliveryTag,
                false
            );
        };

        channel.BasicConsume(
            queue: "cadastro.em.analise.email",
            autoAck: false,
            consumer: consumer
        );
    }
}