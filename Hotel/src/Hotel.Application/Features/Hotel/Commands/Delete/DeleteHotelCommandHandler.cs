using Application.Services;
using Mapster;
using MediatR;

namespace Application.Features.Hotel.Commands.Delete;

public class DeleteHotelCommandHandler:IRequestHandler<DeleteHotelCommand,DeleteHotelCommandResponse>
{
    private readonly IHotelService _hotelService;

    public DeleteHotelCommandHandler(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public async Task<DeleteHotelCommandResponse> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        bool result= await _hotelService.Delete(request.Id,cancellationToken);

        return new DeleteHotelCommandResponse()
        {
            Delete = result
        };
    }
}