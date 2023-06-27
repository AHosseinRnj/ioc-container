using System;
using System.Collections.Generic;
using System.Linq;

namespace ioc_container
{
    public class IocContainer : IIocContainer
    {
        private readonly Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly Dictionary<object, object> _instanceMap = new Dictionary<object, object> { };

        public void Register<TInterface, TImplementation>() where TInterface : class
                                                            where TImplementation : class, TInterface
        {
            if (_map.ContainsKey(typeof(TInterface)))
                throw new InvalidOperationException($"{typeof(TInterface).FullName} is already exists.");

            _map.Add(typeof(TInterface), typeof(TImplementation));
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return (TInterface)Resolve(typeof(TInterface));
        }

        private object Resolve(Type typeToResolve)
        {
            Type implementation;
            if (!_map.TryGetValue(typeToResolve, out implementation))
                throw new InvalidOperationException($"No implementation added for {typeToResolve}");

            if(_instanceMap.ContainsKey(implementation))
                return _instanceMap[implementation];

            // Get constructor
            var constructor = implementation.GetConstructors().FirstOrDefault();
            if (constructor == null)
                Console.WriteLine($"No Constructor found for {implementation}");

            // Get constructor parameters
            var constructorParameters = constructor.GetParameters();
            var parameters = new List<object>();
            foreach (var parametersToResolve in constructorParameters)
            {
                // Resolve parameters recursivly
                parameters.Add(Resolve(parametersToResolve.ParameterType));
            }

            var instance = Activator.CreateInstance(implementation, parameters.ToArray());
            _instanceMap[implementation] = instance;

            return instance;
        }

        public void Dispose() { }
    }
}