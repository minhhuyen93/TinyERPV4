namespace Sercurity.Tasks
{
    using Security.Repositories;
    using Sercurity.Services;
    using TinyERP.Common.DI.IoC;
    using TinyERP.Common.Enums;
    using TinyERP.Common.Task;
    public class Bootstrapper : BaseTask, IBootstrapper
    {
        public Bootstrapper() : base(ApplicationType.WebApi, TaskPriority.Normal) { }
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            IoC.RegisterAsTransient<ISecurityService, SecurityService>();
            IoC.RegisterAsTransient<ISecurityRepository, SecurityRepository>();
        }
    }
}
