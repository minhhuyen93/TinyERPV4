namespace TinyERP.Common.Data.Uow
{
    using System;
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }
        void Commit();
    }
}
