namespace Sercurity.Api
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Security.Aggregate;
    using Security.Command;
    using Sercurity.Command;
    using Sercurity.Services;
    using System.Collections.Generic;
    using TinyERP.Common.Attributes;
    using TinyERP.Common.Authentication;
    using TinyERP.Common.DI.IoC;
    [ApiController]
    [Route("api/security")]
    public class SecurityController : ControllerBase
    {
        [HttpPost("login")]
        [ResponseWrapper()]
        public IAuthenticationResult Login(UserNameAndPwdAuthenticationRequest request)
        {
            ISecurityService service = IoC.Resolve<ISecurityService>();
            return service.Login(request);
        }

        [HttpPost("")]
        [ResponseWrapper()]
        public void CreateUser(CreateUserRequest request)
        {
            ISecurityService service = IoC.Resolve<ISecurityService>();
            service.CreateUser(request);
        }

        [HttpGet("")]
        [ResponseWrapper()]
        [Authorize]
        public IList<User> GetUsers()
        {
            ISecurityService service = IoC.Resolve<ISecurityService>();
            return service.GetUsers();
        }
    }
}
