using FluentValidation;

namespace Report.WebApi.Configurations;

public class ApplicationServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddMediatR(cfr =>
            cfr.RegisterServicesFromAssembly(typeof(Report.Application.AssemblyReference).Assembly));
       
        services.AddValidatorsFromAssembly(typeof(Report.Application.AssemblyReference).Assembly);
    }
}