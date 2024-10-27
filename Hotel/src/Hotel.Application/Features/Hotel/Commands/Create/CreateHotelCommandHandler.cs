using Application.Services;
using Domain.DTOs;
using Mapster;
using MediatR;

namespace Application.Features.Hotel.Commands.Create;

public class CreateHotelCommandHandler:IRequestHandler<CreateHotelCommand,CreateHotelCommandResponse>
{
    private readonly IHotelService _hotelService;

    public CreateHotelCommandHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public async Task<CreateHotelCommandResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        Guid Id= await _hotelService.Create(request.Adapt<HotelDto>(),cancellationToken);

        return new CreateHotelCommandResponse()
        {
            Id = Id
        };
    }
}