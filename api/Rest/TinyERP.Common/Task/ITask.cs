namespace TinyERP.Common.Task
{
    public interface ITask
    {
        int Priority { get; }
        void Execute(ITaskArgument arg);
    }
}
