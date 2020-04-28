namespace Security.Tasks
{
    using Security.Command;
    using Sercurity.Services;
    using System.Collections.Generic;
    using TinyERP.Common.DI.IoC;
    using TinyERP.Common.Task;
    public class CreateDefaultUserIfNotExisted : BaseTask, IBootstrapper
    {
        public CreateDefaultUserIfNotExisted() : base(TinyERP.Common.Enums.ApplicationType.WebApi, TinyERP.Common.Enums.TaskPriority.Medium) { }
        protected override void ExecuteInternal(ITaskArgument arg)
        {
            ISecurityService service = IoC.Resolve<ISecurityService>();
            var users = service.GetUsers();
            if (users.Count != 0) { return; }
            IList<CreateUserRequest> commands = new List<CreateUserRequest>
            {
                new CreateUserRequest
                {
                    UserName = "admin",
                    Password = "Abc123@"
                },
                new CreateUserRequest
                {
                    UserName = "test",
                    Password = "Abc123@"
                }
            };
            foreach (var command in commands)
            {
                service.CreateUser(command);
            }
        }
    }
}
