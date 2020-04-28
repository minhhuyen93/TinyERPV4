namespace Inventory.Services
{
    using Inventory.Command;
    using Inventory.Aggregate;
    using System.Collections.Generic;
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product GetProduct(int id);
        void CreateProduct(CreateProductRequest request);
        void UpdateProduct(UpdateProductRequest request);
        void DeleteProduct(int id);
    }
}
