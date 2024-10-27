using Application.Services;
using Domain.DTOs;
using Mapster;
using MediatR;

namespace Application.Features.Hotel.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryResponse>
{
    private readonly IHotelService _hotelService;

    public GetByIdQueryHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<GetByIdQueryResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        HotelDto hotelDto = await _hotelService.GetById(request.Id, cancellationToken);
        return hotelDto.Adapt<GetByIdQueryResponse>();
    }
}