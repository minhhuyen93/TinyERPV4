namespace Inventory.Context
{
    using Inventory.Aggregate;
    using Inventory.Enums;
    using Microsoft.EntityFrameworkCore;
    using TinyERP.Common.Data;

    public class InventoryContext : BaseDbContext, IInventoryDbContext
    {
        public DbSet<Product> Products { get; set; }
        public InventoryContext() : base(InventoryConfiguration.DbConnection) { }
    }
}
