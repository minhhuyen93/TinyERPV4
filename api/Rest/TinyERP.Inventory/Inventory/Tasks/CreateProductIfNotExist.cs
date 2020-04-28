namespace Inventory.Task
{
    using TinyERP.Common.Task;
    using TinyERP.Common.Enums;
    using System.Collections.Generic;
    using Inventory.Command;
    using Inventory.Services;
    using TinyERP.Common.DI.IoC;

    public class CreateProductIfNotExist : BaseTask, IBootstrapper
    {
        public CreateProductIfNotExist() : base(ApplicationType.WebApi, TaskPriority.Medium) { }
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IProductService service = IoC.Resolve<IProductService>();
            var products = service.GetProducts();
            if (products.Count != 0) { return; }
            IList<CreateProductRequest> commands = new List<CreateProductRequest>
            {
                new CreateProductRequest{
                    Name = "TOYOTA",
                    Price=105,
                    Quantity = 1,
                    Description= "Xe nay chi dung de cho Heo thoi."
                },
                new CreateProductRequest{
                    Name = "SamSung",
                    Price=100,
                    Quantity = 1,
                    Description= "Hang Trung Quoc ai them xai"
                },
                new CreateProductRequest{
                    Name = "Mercerde",
                    Price=1000,
                    Quantity = 10,
                    Description= "Xe nay chay cung binh thuong thoi nha."
                },
            };
            foreach (var command in commands)
            {
                service.CreateProduct(command);
            }
        }
    }
}
