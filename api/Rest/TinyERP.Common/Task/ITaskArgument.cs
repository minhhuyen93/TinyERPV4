namespace TinyERP.Common.Task
{
    using TinyERP.Common.Application;
    public interface ITaskArgument
    {
        IApplication Application { get; set; }
    }
}
