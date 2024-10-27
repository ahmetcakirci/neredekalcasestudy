using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using NerdekalComRepository;

namespace Infrastructure.Repositories;

public class HotelRepository: Repository<Hotel, HotelDbContext>, IHotelRepository
{
    public HotelRepository(HotelDbContext context) : base(context)
    {
    }
}