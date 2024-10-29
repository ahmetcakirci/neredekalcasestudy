using Report.Domain.DTOs;

namespace Report.Application.Services;

public interface IMessageQueueService
{
    void Publish(ReportDto report);
}