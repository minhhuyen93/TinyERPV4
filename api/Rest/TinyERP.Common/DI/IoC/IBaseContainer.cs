namespace TinyERP.Common.DI.IoC
{
    public interface IBaseContainer
    {
        IInterface Resolve<IInterface>(object[] args = null);
        void RegisterAsSingleton<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
        void RegisterAsTransient<IInterface, IImpl>() where IInterface : class where IImpl : IInterface;
    }
}
