namespace Inventory.Task
{
    using Inventory.Repositories;
    using Inventory.Services;
    using TinyERP.Common.DI.IoC;
    using TinyERP.Common.Task;
    using TinyERP.Common.Enums;
    public class Bootstrapper : BaseTask, IBootstrapper
    {
        public Bootstrapper() : base(ApplicationType.WebApi, TaskPriority.Normal) { }

        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<IProductService, ProductService>();
            IoC.RegisterAsTransient<IProductRepository, ProductRepository>();
        }
    }
}
