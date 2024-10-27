using Application.Services;
using Domain.DTOs;

namespace Infrastructure.Services;

public class HotelService:IHotelService
{
    public Task<Guid> Create(HotelDto hotel)
    {
        throw new NotImplementedException();
    }
}