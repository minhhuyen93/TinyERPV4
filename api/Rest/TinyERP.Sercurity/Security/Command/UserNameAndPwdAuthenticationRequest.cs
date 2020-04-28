using TinyERP.Common.Attributes;

namespace Sercurity.Command
{
    public class UserNameAndPwdAuthenticationRequest
    {
        [Required("security.auth.useNameWasRequired")]
        public string UserName { get; set; }
        [Required("security.auth.passwordWasRequired")]
        public string Password { get; set; }
    }
}
