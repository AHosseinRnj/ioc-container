using System;

namespace ioc_container
{
    public class IocContainer : IIocContainer
    {
        public void Register<TInterface, TImplementation>() where TInterface : class
                                                            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }
        public TInterface Resolve<TInterface>() where TInterface : class
        {
            throw new NotImplementedException();
        }
    }
}
