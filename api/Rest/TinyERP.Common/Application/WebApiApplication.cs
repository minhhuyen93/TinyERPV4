using TinyERP.Common.Enums;

namespace TinyERP.Common.Application
{
    internal class WebApiApplication : BaseApplication, IApplication
    {
        public WebApiApplication():base(ApplicationType.WebApi){}
                
    }
}
