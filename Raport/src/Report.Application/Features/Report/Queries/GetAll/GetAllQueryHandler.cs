using Mapster;
using MediatR;
using NeredekalComPagination;
using Report.Application.Services;

namespace Report.Application.Features.Report.Queries.GetAll;

public class GetAllQueryHandler:IRequestHandler<GetAllQuery,PaginationResult<GetAllQueryResponse>>
{
    private readonly IReportService _reportService;

    public GetAllQueryHandler(IReportService reportService)
    {
        _reportService = reportService;
    }
    public async Task<PaginationResult<GetAllQueryResponse>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _reportService.GetAll();
        var pagination=await hotels.ToPagedListAsync(request.PageIndex,request.PageSize,cancellationToken);
        var result = new PaginationResult<GetAllQueryResponse>(pagination.Datas.Adapt<List<GetAllQueryResponse>>(),
            pagination.PageNumber,
            pagination.PageSize,
            pagination.TotalPages);
        
        return result;
    }
}