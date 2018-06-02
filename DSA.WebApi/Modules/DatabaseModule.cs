using Autofac;
using RCS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RCS.WebApi.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateDbContextOptions).As<DbContextOptions<RelativeCommunicationContext>>();
        }

        private static DbContextOptions<RelativeCommunicationContext> CreateDbContextOptions(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();
            string connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<RelativeCommunicationContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            using (var dbContext = new RelativeCommunicationContext(dbContextOptionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();
            }

            return dbContextOptionsBuilder.Options;
        }
        
    }
}
