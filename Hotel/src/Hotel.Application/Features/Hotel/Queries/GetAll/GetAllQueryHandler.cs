using Application.Services;
using Mapster;
using MediatR;
using NeredekalComPagination;

namespace Application.Features.Hotel.Queries.GetAll;

public class GetAllQueryHandler: IRequestHandler<GetAllQuery, PaginationResult<GetAllQueryResponse>>
{
    private readonly IHotelService _hotelService;

    public GetAllQueryHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<PaginationResult<GetAllQueryResponse>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelService.GetAll();
        var pagination=await hotels.ToPagedListAsync(request.PageIndex,request.PageSize,cancellationToken);
        var result = new PaginationResult<GetAllQueryResponse>(pagination.Datas.Adapt<List<GetAllQueryResponse>>(),
            pagination.PageNumber,
            pagination.PageSize,
            pagination.TotalPages);
        
        return result;
    }
}