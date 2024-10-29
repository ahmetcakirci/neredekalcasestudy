namespace Hotel.WebApi.Configuration;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host);
}