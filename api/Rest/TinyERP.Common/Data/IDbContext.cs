namespace TinyERP.Common.Data
{
    using System;
    using TinyERP.Common.Enums;
    public interface IDbContext : IDisposable
    {
        BaseDbSet<TEntity> GetDbSet<TEntity>(IOMode mode) where TEntity : class;
        int SaveChanges();
    }
}
