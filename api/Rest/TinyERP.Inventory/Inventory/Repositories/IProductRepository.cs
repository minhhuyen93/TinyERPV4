using Inventory.Aggregate;
using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetAlls();
        Product GetById(int id);
        void Create(Product product);
        Product GetByName(string name);
        void Update(Product product);
        void Delete(int id);
    }
}
