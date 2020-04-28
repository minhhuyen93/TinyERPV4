namespace Sercurity.Services
{
    using Security.Aggregate;
    using Security.Command;
    using Sercurity.Command;
    using System.Collections.Generic;
    using TinyERP.Common.Authentication;
    public interface ISecurityService
    {
        IAuthenticationResult Login(UserNameAndPwdAuthenticationRequest request);
        IList<User> GetUsers();
        void CreateUser(CreateUserRequest command);
    }
}
