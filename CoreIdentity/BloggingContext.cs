using CoreIdentity.Models;
using CoreIdentity.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity
{
    public class BloggingContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("AspNetUsers");
                builder.Property(p => p.Id).HasColumnType("int");
            });
            modelBuilder.Entity<UserPost>(builder =>
            {
                builder.HasOne(userPost => userPost.Post).WithMany(post => post.UserPosts).HasForeignKey(userPost => userPost.PostId);
                builder.HasOne(userPost => userPost.User).WithMany(user => user.UserPosts).HasForeignKey(userPost => userPost.UserId);
                builder.ToTable("UserPost");
            });
        }
    }
}