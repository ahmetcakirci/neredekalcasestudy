using Report.Domain.DTOs;

namespace Report.Application.Services;

public interface IReportService
{
    Task<Guid> Create(ReportDto request, CancellationToken cancellationToken);
    Task<bool> Update(ReportDto request, CancellationToken cancellationToken);
    Task<IQueryable<Domain.Entities.Report>> GetAll();
}