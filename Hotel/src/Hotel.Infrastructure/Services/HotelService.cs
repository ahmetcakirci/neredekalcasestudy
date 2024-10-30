using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Mapster;
using NerdekalComRepository;

namespace Infrastructure.Services;

public class HotelService:IHotelService
{
    private readonly IHotelRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public HotelService(IHotelRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Create(HotelDto request, CancellationToken cancellationToken)
    {
        Hotel hotel= request.Adapt<Hotel>();

        await _repository.AddAsync(hotel, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return hotel.Id;
    }
    
    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        Hotel? hotel = await _repository.GetByExpressionAsync(x => x.Id == id);
        if (hotel is null)
            return false;
        
        _repository.Delete(hotel);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<bool> Update(HotelDto request, CancellationToken cancellationToken)
    {
        Hotel? hotel = await _repository.GetByExpressionAsync(x => x.Id == request.Id);
        if (hotel is null)
            return false;

        hotel.AuthorizedFirstName = request.AuthorizedFirstName;
        hotel.AuthorizedLastName = request.AuthorizedLastName;
        hotel.CompanyTitle = request.CompanyTitle;

        _repository.Update(hotel);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
    
    public async Task<HotelDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        Hotel? hotel = await _repository.GetByExpressionAsync(x => x.Id == id,cancellationToken);
        if (hotel is not null)
        {
            return hotel.Adapt<HotelDto>();
        }
        return new HotelDto();
    }
    
    public Task<IQueryable<Hotel>> GetAll()
    {
        var hotels =  _repository.GetAllWithTracking();
        return Task.FromResult(hotels);
    }
    public Task<ReportDto> GetLocationReport(string locationInfo)
    {
        var reports = _repository.GetAll()
            .Where(h => h.ContactInfos.Any(ci =>
                ci.InfoType == ContactInfoType.Location && ci.InfoContent == locationInfo))
            .ToList();

        var report = new ReportDto()
        {
            LocationInfo = locationInfo,
            HotelCount = reports.Count,
            PhoneNumberCount = reports.Sum(h => h.ContactInfos.Count(ci => ci.InfoType == ContactInfoType.PhoneNumber))
        };
        
        return Task.FromResult(report);
    }
}