namespace Domain.UnitOfWork;
public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public Task BeginTransactionAsync(CancellationToken cancellationToken);
    public Task CommitTransactionAsync(CancellationToken cancellationToken);
    public Task RollbackTransactionAsync(CancellationToken cancellationToken);

}

