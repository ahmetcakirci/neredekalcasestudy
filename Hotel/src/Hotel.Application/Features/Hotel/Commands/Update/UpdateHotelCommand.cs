using Domain.DTOs;
using MediatR;

namespace Application.Features.Hotel.Commands.Update;

public sealed record UpdateHotelCommand(
    Guid Id , 
    string AuthorizedFirstName,
    string AuthorizedLastName,
    string CompanyTitle,
    List<ContactInfoDto> ContactInfos) : IRequest<UpdateHotelCommandResponse>;