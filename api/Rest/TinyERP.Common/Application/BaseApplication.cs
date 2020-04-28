namespace TinyERP.Common.Application
{
    using TinyERP.Common.Enums;
    using TinyERP.Common.Helpers;
    using TinyERP.Common.Task;
    public abstract class BaseApplication : IApplication
    {
        public ApplicationType Type { get; private set; }
        public BaseApplication(ApplicationType type)
        {
            this.Type = type;
        }
        public virtual void OnApplicationEnded()
        {
            AssemblyHelper.Execute<IApplicationEnded>(this.GetTaskArgument());
        }

        public virtual void OnApplicationStarted()
        {
            AssemblyHelper.Execute<IBootstrapper>(this.GetTaskArgument());
            AssemblyHelper.Execute<IApplicationStarted>(this.GetTaskArgument());
        }
        private ITaskArgument GetTaskArgument()
        {
            ITaskArgument arg = new TaskArgument();
            arg.Application = this;
            return arg;
        }
    }
}
