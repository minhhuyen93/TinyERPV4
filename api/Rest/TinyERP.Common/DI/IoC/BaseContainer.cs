namespace TinyERP.Common.DI.IoC
{
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using TinyERP.Common.Helpers;

    public class BaseContainer : IBaseContainer
    {
        private IWindsorContainer _container;
        public BaseContainer()
        {
            this._container = new WindsorContainer();
        }

        public void RegisterAsSingleton<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this._container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifeStyle.Singleton);
        }

        public void RegisterAsTransient<IInterface, IImpl>()
            where IInterface : class
            where IImpl : IInterface
        {
            this._container.Register(Component.For<IInterface>().ImplementedBy<IImpl>().LifeStyle.Transient);
        }

        public IInterface Resolve<IInterface>(object[] args = null)
        {
            if (args == null || args.Length == 0)
            {
                return this._container.Resolve<IInterface>();
            }
            Arguments winsorArg = new Arguments();
            for (int index = 0; index < args.Length; index++)
            {
                if (args[index] == null)
                {
                    continue;
                }
                IList<Type> types = AssemblyHelper.GetInterfaces(args[index]);
                foreach (Type item in types)
                {
                    winsorArg.AddTyped(item, args[index]);
                }
            }
            return this._container.Resolve<IInterface>(winsorArg);
        }
    }
}
