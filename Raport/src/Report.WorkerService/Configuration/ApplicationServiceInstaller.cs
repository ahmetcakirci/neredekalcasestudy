using FluentValidation;

namespace Report.WorkerService.Configuration;

public class ApplicationServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfr =>
            cfr.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
       
        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
    }
}