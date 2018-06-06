using CoreIdentity.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CoreIdentity.Core.Data
{
    public interface IEntitiesContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsyncContext();
        Task<int> SaveChangesAsyncContext(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> CommitAsync();
    }
}
