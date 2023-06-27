using System;
using System.Collections.Generic;

namespace ioc_container
{
    public class IocContainer : IIocContainer
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>() where TInterface : class
                                                            where TImplementation : class, TInterface
        {
            if (_map.ContainsKey(typeof(TInterface)))
                throw new InvalidOperationException($"{typeof(TInterface).FullName} is already exists.");

            _map.Add(typeof(TInterface), typeof(TImplementation));
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            throw new NotImplementedException();
        }
    }
}
