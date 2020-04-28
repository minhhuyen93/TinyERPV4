namespace TinyERP.Common.Data
{
    using TinyERP.Common.Enums;
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private IDbContext dbContext;
        protected BaseDbSet<TEntity> DbSet { get; private set; }
        public BaseRepository() : this(DbContextFactory.CreateContext<TEntity>(), IOMode.ReadOnly) { }
        public BaseRepository(IDbContext dbContext, IOMode mode = IOMode.Write)
        {
            this.DbSet = dbContext.GetDbSet<TEntity>(mode);
            this.dbContext = dbContext;
        }
        public void Create(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

    }
}
