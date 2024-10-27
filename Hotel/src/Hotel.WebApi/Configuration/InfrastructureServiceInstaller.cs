using Application.Services;
using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using NerdekalComRepository;

namespace WebApi.Configuration;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<HotelDbContext>(options => {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        
        services.AddScoped<IHotelService, HotelService>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork<HotelDbContext>>();
        services.AddScoped<IHotelRepository, HotelRepository>();
    }
}