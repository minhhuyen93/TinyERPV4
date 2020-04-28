using TinyERP.Common.Enums;

namespace TinyERP.Common.Task
{
    public class BaseTask : ITask
    {
        public int Priority { get; private set; }
        public ApplicationType AppType { get; private set; }
        public BaseTask(ApplicationType appType = ApplicationType.All, TaskPriority priority = TaskPriority.Normal)
        {
            this.AppType = appType;
            this.Priority = (int)priority;
        }
        public void Execute(ITaskArgument arg)
        {
            if (this.AppType != ApplicationType.All && arg.Application.Type != this.AppType) { return; }
            this.ExecuteInternal(arg);
        }
        protected virtual void ExecuteInternal(ITaskArgument arg) { }
    }
}
