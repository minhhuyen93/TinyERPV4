namespace Sercurity.Services
{
    using Security.Aggregate;
    using Security.Command;
    using Security.Repositories;
    using Sercurity.Command;
    using System.Collections.Generic;
    using TinyERP.Common.Authentication;
    using TinyERP.Common.Data.Uow;
    using TinyERP.Common.DI.IoC;
    using TinyERP.Common.Exceptions;
    using TinyERP.Common.Helpers;
    using TinyERP.Common.Services;

    internal class SecurityService : BaseService, ISecurityService
    {
        public void CreateUser(CreateUserRequest command)
        {
            this.Validate(command);
            using (IUnitOfWork uow = this.CreateUnitOfWork<User>())
            {
                ISecurityRepository repo = IoC.Resolve<ISecurityRepository>(uow);
                User user = new User();
                user.UserName = command.UserName;
                user.Password = command.Password;
                repo.Create(user);
                uow.Commit();
            }
        }
        private void Validate(CreateUserRequest command)
        {
            IList<string> errorMessages = ValidationHelper.GetErrorMessages(command);
            ISecurityRepository repo = IoC.Resolve<ISecurityRepository>();
            User user = repo.GetByUserName(command.UserName);
            if (user != null)
            {
                errorMessages.Add("security.auth.userNameWasExisted");
            }
            if (errorMessages.Count > 0)
            {
                throw new ValidationException(errorMessages);
            }
        }

        public IList<User> GetUsers()
        {
            ISecurityRepository repo = IoC.Resolve<ISecurityRepository>();
            return repo.GetAlls();
        }

        public IAuthenticationResult Login(UserNameAndPwdAuthenticationRequest request)
        {
            this.Validate(request);
            ISecurityRepository repo = IoC.Resolve<ISecurityRepository>();
            User user = repo.GetUserByUserNameAndPwd(request.UserName, request.Password);
            string secretKey = FileHelper.GetAppSettingsConfiguration("appsettings.json").SecretKey;
            string authToken = JWTHelper.CreateTokenWithSercetKey(user.UserName, secretKey);
            AuthenticationResult result = new AuthenticationResult();
            result.AuthToken = authToken;
            return result;
        }
        private void Validate(UserNameAndPwdAuthenticationRequest request)
        {
            IList<string> errorMessages = ValidationHelper.GetErrorMessages(request);
            ISecurityRepository repo = IoC.Resolve<ISecurityRepository>();
            User user = repo.GetUserByUserNameAndPwd(request.UserName, request.Password);
            if (user == null)
            {
                errorMessages.Add("security.auth.userNameOrPasswordInValid");
            }
            if (errorMessages.Count > 0)
            {
                throw new ValidationException(errorMessages);
            }
        }
    }
}
