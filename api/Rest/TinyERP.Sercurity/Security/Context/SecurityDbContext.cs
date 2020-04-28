namespace Security.Context
{
    using Microsoft.EntityFrameworkCore;
    using Security.Aggregate;
    using Security.Enums;
    using TinyERP.Common.Data;
    public class SecurityDbContext : BaseDbContext, ISecurityDbContext
    {
        public SecurityDbContext() : base(SecurityConfiguration.DbConnection) { }

        public DbSet<User> Users { get; set; }
    }
}
