using Domain.DTOs;

namespace Application.Services;

public interface IHotelService
{
    Task<Guid> Create(HotelDto hotel);
}