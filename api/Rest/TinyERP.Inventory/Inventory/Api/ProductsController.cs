namespace Inventory.Controllers
{
    using System.Collections.Generic;
    using Inventory.Command;
    using Inventory.Aggregate;
    using Inventory.Services;
    using Microsoft.AspNetCore.Mvc;
    using TinyERP.Common.Attributes;
    using TinyERP.Common.DI.IoC;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    [Route("api/inventory/products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        [HttpGet("")]
        [ResponseWrapper()]
        public IList<Product> GetProducts()
        {
            IProductService service = IoC.Resolve<IProductService>();
            return service.GetProducts();
        }

        [HttpGet("{id}")]
        [ResponseWrapper()]
        public Product GetProduct(int id)
        {
            IProductService service = IoC.Resolve<IProductService>();
            return service.GetProduct(id);
        }

        [HttpPost("")]
        [ResponseWrapper()]
        public void AddProduct(CreateProductRequest request)
        {
            IProductService service = IoC.Resolve<IProductService>();
            service.CreateProduct(request);
        }
        [HttpPost("{id}")]
        [ResponseWrapper()]
        public void UpdateProduct(UpdateProductRequest request, int id)
        {
            request.Id = id;
            IProductService service = IoC.Resolve<IProductService>();
            service.UpdateProduct(request);
        }
        [HttpDelete("{id}")]
        [ResponseWrapper()]
        public void DeleteProduct(int id)
        {
            IProductService service = IoC.Resolve<IProductService>();
            service.DeleteProduct(id);
        }

    }
}