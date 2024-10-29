using Report.WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ReportWorker>();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",false,true)
    .AddEnvironmentVariables();

var host = builder.Build();
host.Run();