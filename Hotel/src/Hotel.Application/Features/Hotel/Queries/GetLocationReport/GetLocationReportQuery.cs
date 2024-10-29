using MediatR;
using NeredekalComPagination;

namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQuery:IRequest<PaginationResult<GetLocationReportQueryResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}