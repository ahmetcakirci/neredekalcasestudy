using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Report.Infrastructure.Configurations;

public class ReportConfiguration: IEntityTypeConfiguration<Report.Domain.Entities.Report>
{
    public void Configure(EntityTypeBuilder<Report.Domain.Entities.Report> builder)
    {
        builder.ToTable("Reports");
        builder.HasKey(ci => ci.Id);
    }
}