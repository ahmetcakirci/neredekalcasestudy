using Microsoft.EntityFrameworkCore;

namespace NerdekalComRepository;

public sealed class UnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
{
    private readonly TContext _context;

    public UnitOfWork(TContext context) => this._context = context;

    public int SaveChanges() => this._context.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        int num = await this._context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return num;
    }
    
    public  void Dispose()
    {
        _context.Dispose();
    }
}