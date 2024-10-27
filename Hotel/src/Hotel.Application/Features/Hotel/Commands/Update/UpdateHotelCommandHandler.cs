using Application.Services;
using Domain.DTOs;
using Mapster;
using MediatR;

namespace Application.Features.Hotel.Commands.Update;

public class UpdateHotelCommandHandler:IRequestHandler<UpdateHotelCommand,UpdateHotelCommandResponse>
{
    private readonly IHotelService _hotelService;

    public UpdateHotelCommandHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public async Task<UpdateHotelCommandResponse> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        bool result= await _hotelService.Update(request.Adapt<HotelDto>(),cancellationToken);

        return new UpdateHotelCommandResponse()
        {
            Update = result
        };
    }
}