using TinyERP.Common.Data.Uow;

namespace TinyERP.Common.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork CreateUnitOfWork<TEntity>()
        {
            return UnitOfWorkFactory.Create<TEntity>();
        }
    }
}
