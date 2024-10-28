using Microsoft.EntityFrameworkCore;
using Report.Domain.Abstractions;

namespace Report.Infrastructure.Context;

public class ReportDbContext: DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefence).Assembly);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entires = ChangeTracker.Entries<Entity>();
        foreach (var entry in entires)
        {
            if(entry.State == EntityState.Added)
                entry.Property(p=> p.CreatedDate)
                    .CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdatedDate)
                    .CurrentValue = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}