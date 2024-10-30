using MediatR;
using NeredekalComPagination;

namespace Report.Application.Features.Report.Queries.GetAll;

public class GetAllQuery:IRequest<PaginationResult<GetAllQueryResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}