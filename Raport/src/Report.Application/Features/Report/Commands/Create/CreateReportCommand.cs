using MediatR;

namespace Report.Application.Features.Report.Commands.Create;

public class CreateReportCommand:IRequest<CreateReportCommandResponse>
{
    public string LocationInfo { get; set; }
}