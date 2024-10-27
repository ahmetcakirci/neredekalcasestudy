using Domain.DTOs;
using MediatR;

namespace Application.Features.Hotel.Commands.Create;
public sealed record CreateHotelCommand(
                string AuthorizedFirstName,
                string AuthorizedLastName,
                string CompanyTitle,
                List<ContactInfoDto> ContactInfos) : IRequest<CreateHotelCommandResponse>;