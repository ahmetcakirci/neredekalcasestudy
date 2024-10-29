using FluentValidation;

namespace Hotel.WebApi.Configuration;

public class ApplicationServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddMediatR(cfr =>
            cfr.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
       
        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
    }
}