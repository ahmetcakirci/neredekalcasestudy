using MediatR;
using NeredekalComPagination;

namespace Application.Features.Hotel.Queries.GetAll;

public class GetAllQuery:IRequest<PaginationResult<GetAllQueryResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}