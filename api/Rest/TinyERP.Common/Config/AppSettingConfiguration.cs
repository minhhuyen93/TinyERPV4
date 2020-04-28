namespace TinyERP.Common.Config
{
    public class AppSettingConfiguration
    {
        public string SecretKey { get; set; }
        public Authentication Authentication { get; set; }
    }
    public class Authentication
    {
        public string AppIdUri { get; set; }
    }
}
