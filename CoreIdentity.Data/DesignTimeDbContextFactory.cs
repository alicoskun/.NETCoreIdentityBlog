using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoreIdentity.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BloggingContext>();

            var connectionString = configuration.GetConnectionString("BloggingDatabase");

            builder.UseSqlServer(connectionString);

            return new BloggingContext(builder.Options);
        }
    }
}
