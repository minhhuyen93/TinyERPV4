namespace Inventory.Aggregate
{
    using Inventory.Context;
    using TinyERP.Common.Attributes;
    [DbContextAttribute(Use = typeof(IInventoryDbContext))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
