using MediatR;

namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQuery:IRequest<GetLocationReportQueryResponse>
{
    public string? LocationInfo { get; set; }
}