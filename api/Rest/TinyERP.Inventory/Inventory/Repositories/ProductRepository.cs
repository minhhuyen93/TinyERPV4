namespace Inventory.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Inventory.Context;
    using Inventory.Aggregate;
    using TinyERP.Common.Data;
    using TinyERP.Common.Data.Uow;

    internal class ProductRepository : BaseRepository<Aggregate.Product>, IProductRepository
    {
        public ProductRepository() : base() { }
        public ProductRepository(IUnitOfWork uow) : base(uow.Context) { }

        public void Delete(int id)
        {
            InventoryContext context = new InventoryContext();
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public IList<Product> GetAlls()
        {
            return this.DbSet.AsQueryable().ToList();
        }

        public Product GetById(int id)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
        public Product GetByName(string name)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(x => x.Name == name);
        }

        public void Update(Product product)
        {
            InventoryContext context = new InventoryContext();
            Product currentItem = context.Products.FirstOrDefault(x => x.Id == product.Id);
            currentItem.Name = product.Name;
            currentItem.Price = product.Price;
            currentItem.Quantity = product.Quantity;
            currentItem.Description = product.Description;
            context.SaveChanges();
        }
    }
}
