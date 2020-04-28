
namespace TinyERP.Common.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using TinyERP.Common.Enums;
    using TinyERP.Common.Helpers;

    public class BaseDbContext : DbContext, IDbContext
    {
        private string connectionString;
        public BaseDbContext(string connectionStringKey)
        {
            this.connectionString = DataBaseConnectionHelper.GetConnectionString(connectionStringKey);
        }

        public BaseDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class
        {
            return new BaseDbSet<TEntity>(this, mode);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
