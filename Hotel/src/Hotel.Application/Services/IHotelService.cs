using Domain.DTOs;
using Domain.Entities;

namespace Application.Services;

public interface IHotelService
{
    Task<Guid> Create(HotelDto hotel, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    Task<bool> Update(HotelDto hotel, CancellationToken cancellationToken);
    Task<HotelDto> GetById(Guid id, CancellationToken cancellationToken);
    Task<IQueryable<Hotel>> GetAll();
    Task<ReportDto> GetLocationReport(string locationInfo);
}