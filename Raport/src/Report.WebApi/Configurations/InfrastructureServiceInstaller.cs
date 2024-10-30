using Microsoft.EntityFrameworkCore;
using NerdekalComRepository;
using Report.Application.Services;
using Report.Domain.Repositories;
using Report.Infrastructure.Context;
using Report.Infrastructure.Repositories;
using Report.Infrastructure.Services;

namespace Report.WebApi.Configurations;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ReportDbContext>(options =>
        {
            options.UseNpgsql(connectionString
                ,b => b.MigrationsAssembly("Report.WebApi")
                );
        });
        
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IMessageQueueService, RabbitMqService>();

        services.AddScoped<IUnitOfWork, UnitOfWork<ReportDbContext>>();
        services.AddScoped<IReportRepository, ReportRepository>();
    }
}