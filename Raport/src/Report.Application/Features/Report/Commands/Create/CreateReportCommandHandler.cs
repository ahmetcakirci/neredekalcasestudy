using MediatR;
using Report.Application.Services;
using Report.Domain.DTOs;
using Report.Domain.Enums;

namespace Report.Application.Features.Report.Commands.Create;

public class CreateReportCommandHandler:IRequestHandler<CreateReportCommand,CreateReportCommandResponse>
{
    private readonly IMessageQueueService _messageQueueService;
    private readonly IReportService _reportService;

    public CreateReportCommandHandler(IReportService reportService, IMessageQueueService messageQueueService)
    {
        _reportService = reportService;
        _messageQueueService = messageQueueService;
    }
    public async Task<CreateReportCommandResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var report = new ReportDto()
        {
            RequestedDate = DateTime.UtcNow,
            Status = ReportStatus.Preparing,
            LocationInfo = request.LocationInfo
        };

        Guid id=await _reportService.Create(report,cancellationToken);
        report.Id = id;
        
        _messageQueueService.Publish(report);
        
        return new CreateReportCommandResponse()
        {
            Id = id
        };
    }
}