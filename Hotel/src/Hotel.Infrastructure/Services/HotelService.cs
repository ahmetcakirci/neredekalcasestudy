using Application.Services;
using Domain.DTOs;
using Domain.Entities;
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
}