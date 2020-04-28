namespace Security.Repositories
{
    using Security.Aggregate;
    using System.Collections.Generic;
    using System.Linq;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.Uow;

    internal class SecurityRepository : BaseRepository<Aggregate.User>, ISecurityRepository
    {
        public SecurityRepository() : base() { }
        public SecurityRepository(IUnitOfWork uow) : base(uow.Context) { }

        public IList<User> GetAlls()
        {
            return this.DbSet.AsQueryable().ToList();
        }

        public User GetByUserName(string userName)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(x => x.UserName == userName);
        }

        public User GetUserByUserNameAndPwd(string userName, string password)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

    }
}
