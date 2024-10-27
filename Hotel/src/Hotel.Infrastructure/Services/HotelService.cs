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
}