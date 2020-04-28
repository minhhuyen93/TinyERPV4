namespace TinyERP.Common.Application
{
    using System;
    using TinyERP.Common.Enums;
    public static class ApplicationFactory
    {
        public static IApplication Create(ApplicationType type)
        {
            switch (type)
            {
                case ApplicationType.WebApi:
                    return new WebApiApplication();

                default:
                    throw new Exception("Unsopport Application Type");
            }
        }
    }
}
