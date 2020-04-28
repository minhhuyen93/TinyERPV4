namespace Inventory.Services
{
    using Inventory.Command;
    using Inventory.Aggregate;
    using Inventory.Repositories;
    using System.Collections.Generic;
    using TinyERP.Common.DI.IoC;
    using TinyERP.Common.Exceptions;
    using TinyERP.Common.Helpers;
    using TinyERP.Common.Data.Uow;
    using TinyERP.Common.Services;

    internal class ProductService : BaseService, IProductService
    {
        public IList<Product> GetProducts()
        {
            IProductRepository repo = IoC.Resolve<IProductRepository>();
            return repo.GetAlls();
        }
        public Product GetProduct(int id)
        {
            IProductRepository repo = IoC.Resolve<IProductRepository>();
            return repo.GetById(id);
        }

        public void CreateProduct(CreateProductRequest request)
        {
            this.Validate(request);
            using (IUnitOfWork uow = this.CreateUnitOfWork<Product>())
            {
                IProductRepository repo = IoC.Resolve<IProductRepository>(uow);
                Product product = new Product();
                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                repo.Create(product);
                uow.Commit();
            }
        }
        private void Validate(CreateProductRequest request)
        {
            IList<string> errorMessages = ValidationHelper.GetErrorMessages(request);
            IProductRepository repo = IoC.Resolve<IProductRepository>();
            Aggregate.Product product = repo.GetByName(request.Name);
            if (product != null)
            {
                errorMessages.Add("inventory.addOrEdit.nameWasExisted");
            }
            if (errorMessages.Count > 0)
            {
                throw new ValidationException(errorMessages);
            }
        }

        public void UpdateProduct(UpdateProductRequest request)
        {
            this.Validate(request);
            IProductRepository repo = IoC.Container.Resolve<IProductRepository>();
            Product product = repo.GetById(request.Id);
            product.Name = request.Name;
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            product.Description = request.Description;
            repo.Update(product);
        }

        public void DeleteProduct(int id)
        {
            IProductRepository repo = IoC.Resolve<IProductRepository>();
            repo.Delete(id);
        }
    }
}
