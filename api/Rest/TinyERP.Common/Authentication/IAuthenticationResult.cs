namespace TinyERP.Common.Authentication
{
    public interface IAuthenticationResult
    {
        string AuthToken { get; set; }
        public virtual int Sum()
        {
            return 1;
        }
    }
}
