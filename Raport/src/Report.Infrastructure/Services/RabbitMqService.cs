using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Report.Application.Services;
using Report.Domain.DTOs;

namespace Report.Infrastructure.Services;

public class RabbitMqService:IMessageQueueService
{
    public void Publish(ReportDto report)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "reportQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var message = JsonSerializer.Serialize(report);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "", routingKey: "reportQueue", basicProperties: null, body: body);
    }
}