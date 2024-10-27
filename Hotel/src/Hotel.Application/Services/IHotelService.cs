using Domain.DTOs;

namespace Application.Services;

public interface IHotelService
{
    Task<Guid> Create(HotelDto hotel, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    Task<bool> Update(HotelDto hotel, CancellationToken cancellationToken);
}