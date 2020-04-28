using TinyERP.Common.Application;

namespace TinyERP.Common.Task
{
    public class TaskArgument : ITaskArgument
    {
        public IApplication Application { get; set; }
        public TaskArgument()
        {

        }
    }
}
