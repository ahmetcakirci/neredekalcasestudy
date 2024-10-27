using MediatR;

namespace Application.Features.Hotel.Commands.Delete;

public sealed record DeleteHotelCommand(Guid Id) : IRequest<DeleteHotelCommandResponse>;