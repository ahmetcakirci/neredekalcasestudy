using Mapster;
using NerdekalComRepository;
using Report.Application.Services;
using Report.Domain.DTOs;
using Report.Domain.Repositories;

namespace Report.Infrastructure.Services;

public class ReportService:IReportService
{
    private readonly IReportRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public ReportService(IReportRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Create(ReportDto request, CancellationToken cancellationToken)
    {
        Domain.Entities.Report report= request.Adapt<Domain.Entities.Report>();

        await _repository.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return report.Id;
    }
    public async Task<bool> Update(ReportDto request, CancellationToken cancellationToken)
    {
        Domain.Entities.Report ? report = await _repository.GetByExpressionAsync(x => x.Id == request.Id);
        if (report is null)
            return false;

        report.Status = request.Status;
        report.HotelCount = request.HotelCount;
        report.PhoneNumberCount = request.PhoneNumberCount;

        _repository.Update(report);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
    public Task<IQueryable<Domain.Entities.Report>> GetAll()
    {
        var reports =  _repository.GetAllWithTracking();
        return Task.FromResult(reports);
    }
}