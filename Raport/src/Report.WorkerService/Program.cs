using Report.WorkerService;
using Report.WorkerService.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ReportWorker>();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",false,true)
    .AddEnvironmentVariables();

builder.Services
    .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly);

var host = builder.Build();
host.Run();