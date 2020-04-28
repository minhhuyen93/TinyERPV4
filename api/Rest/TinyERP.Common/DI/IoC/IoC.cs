namespace TinyERP.Common.DI.IoC
{
    public class IoC
    {
        public static IBaseContainer Container;
        static IoC()
        {
            IoC.Container = new BaseContainer();
        }
        public static TResult Resolve<TResult>(params object[] args) where TResult : class
        {
            return IoC.Container.Resolve<TResult>(args);
        }

        public static void RegisterAsSingleton<IInterface, Impl>()
            where IInterface : class where Impl : IInterface
        {
            IoC.Container.RegisterAsSingleton<IInterface, Impl>();
        }

        public static void RegisterAsTransient<IInterface, Impl>()
            where IInterface : class where Impl : IInterface
        {
            IoC.Container.RegisterAsTransient<IInterface, Impl>();
        }
    }
}
