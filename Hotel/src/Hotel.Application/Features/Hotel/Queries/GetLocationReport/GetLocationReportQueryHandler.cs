using Application.Services;
using Mapster;
using MediatR;
using NeredekalComPagination;

namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQueryHandler: IRequestHandler<GetLocationReportQuery, PaginationResult<GetLocationReportQueryResponse>>
{
    private readonly IHotelService _hotelService;

    public GetLocationReportQueryHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<PaginationResult<GetLocationReportQueryResponse>> Handle(GetLocationReportQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelService.GetAll();
        var pagination=await hotels.ToPagedListAsync(request.PageIndex,request.PageSize,cancellationToken);
        
        return pagination.Adapt<PaginationResult<GetLocationReportQueryResponse>>();
    }
}