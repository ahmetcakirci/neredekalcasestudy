using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.Domain.DTOs;
using Report.Domain.Enums;
using Report.Infrastructure.Clients;
using Report.Infrastructure.Services;

namespace Report.WorkerService;

public class ReportWorker : BackgroundService
{
    private readonly ILogger<ReportWorker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public ReportWorker(IServiceScopeFactory scopeFactory,ILogger<ReportWorker> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost",Port = 5670};
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "reportQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var report = JsonSerializer.Deserialize<ReportDto>(message);
            
            using var scope = _scopeFactory.CreateScope();
            var reportService = scope.ServiceProvider.GetRequiredService<ReportService>();
            var _hotelClient = scope.ServiceProvider.GetRequiredService<IHotelReport>();

            var client=await _hotelClient.GetHotelLocation(report?.LocationInfo);
            var updateReport = new ReportDto()
            {
                Id = report.Id,
                RequestedDate = DateTime.UtcNow,
                LocationInfo = report?.LocationInfo,
                Status=ReportStatus.Completed,
                HotelCount=client.Content?.HotelCount,
                PhoneNumberCount = client.Content?.PhoneNumberCount
            };
            bool isUpdate=await reportService.Update(updateReport, stoppingToken);
        };

        channel.BasicConsume(queue: "reportQueue", autoAck: true, consumer: consumer);

        await Task.CompletedTask;
    }
}