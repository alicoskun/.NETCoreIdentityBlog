using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoreIdentity.Core.Data;
using CoreIdentity.DomainModels;
using CoreIdentity.DomainModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoreIdentity.Data
{
    public class BloggingContext : IdentityDbContext<User, IdentityRole<int>, int>, IEntitiesContext
    {
        private DbConnection _connection;
        private DbTransaction _transaction;
        private static readonly object Lock = new object();

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("AspNetUsers");
                builder.Property(p => p.Id).HasColumnType("int");
            });
            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<UserPost>(builder =>
            {
                builder.HasOne(userPost => userPost.Post).WithMany(post => post.UserPosts).HasForeignKey(userPost => userPost.PostId);
                builder.HasOne(userPost => userPost.User).WithMany(user => user.UserPosts).HasForeignKey(userPost => userPost.UserId);
                builder.ToTable("UserPost");
            });
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            DetachLocalEntity(entity);
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public void BeginTransaction()
        {
            _connection = Database.GetDbConnection();

            if (_connection.State == ConnectionState.Open)
            {
                return;
            }
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public int Commit()
        {
            var saveChanges = SaveChanges();
            _transaction.Commit();
            return saveChanges;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public Task<int> CommitAsync()
        {
            var saveChangesAsync = SaveChangesAsync();
            _transaction.Commit();
            return saveChangesAsync;
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : BaseEntity
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private EntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }
        
        private void DetachLocalEntity<TEntity>(TEntity newEntity) where TEntity : BaseEntity
        {
            var localEntity = Set<TEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(newEntity.Id));

            if (localEntity != null)
            {
                Entry(localEntity).State = EntityState.Detached;
            }
            Entry(newEntity).State = EntityState.Modified;
        }

        public Task<int> SaveChangesAsyncContext()
        {
            return SaveChangesAsync();
        }

        public Task<int> SaveChangesAsyncContext(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }

        public override void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            base.Dispose();
        }
    }
}