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
        throw new NotImplementedException();
    }
}