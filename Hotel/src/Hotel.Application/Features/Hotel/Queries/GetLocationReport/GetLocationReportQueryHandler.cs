using Application.Services;
using Mapster;
using MediatR;
using NeredekalComPagination;

namespace Application.Features.Hotel.Queries.GetLocationReport;

public class GetLocationReportQueryHandler: IRequestHandler<GetLocationReportQuery, GetLocationReportQueryResponse>
{
    private readonly IHotelService _hotelService;

    public GetLocationReportQueryHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<GetLocationReportQueryResponse> Handle(GetLocationReportQuery request, CancellationToken cancellationToken)
    {
        var reports = await _hotelService.GetLocationReport(request.LocationInfo);
        return reports.Adapt<GetLocationReportQueryResponse>();
    }
}