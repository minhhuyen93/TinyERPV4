using TinyERP.Common.Enums;

namespace TinyERP.Common.Application
{
    public interface IApplication
    {
        ApplicationType Type { get; }
        void OnApplicationStarted();
        void OnApplicationEnded();
    }
}
