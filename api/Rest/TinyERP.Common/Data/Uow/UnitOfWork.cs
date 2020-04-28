namespace TinyERP.Common.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbContext Context { get; private set; }
        public UnitOfWork(IDbContext context)
        {
            this.Context = context;
        }
        public void Dispose()
        {
            this.Context.Dispose();
        }
        public void Commit()
        {
            this.Context.SaveChanges();
        }
    }
}
