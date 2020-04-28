namespace TinyERP.Common.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using TinyERP.Common.Enums;
    public class BaseDbSet<TEntity> where TEntity : class
    {
        private DbContext dbContext;
        private IOMode mode;
        private DbSet<TEntity> dbSet;
        public BaseDbSet(DbContext dbContext, IOMode mode)
        {
            this.dbContext = dbContext;
            this.mode = mode;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (this.mode == IOMode.ReadOnly)
            {
                throw new System.Exception(string.Format("invalid mode:{0}", mode));
            }

            this.dbSet.Add(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return mode == IOMode.ReadOnly ? this.dbSet.AsNoTracking<TEntity>() : this.dbSet;
        }
    }
}
