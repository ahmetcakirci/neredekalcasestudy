using NerdekalComRepository;
using Report.Domain.Repositories;
using Report.Infrastructure.Context;

namespace Report.Infrastructure.Repositories;

public class ReportRepository: Repository<Domain.Entities.Report, ReportDbContext>, IReportRepository
{
    public ReportRepository(ReportDbContext context) : base(context)
    {
    }
}