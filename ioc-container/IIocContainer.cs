namespace ioc_container
{
    public interface IIocContainer
    {
        void Register<TInterface, TImplementation>() where TInterface : class
                                                     where TImplementation : class, TInterface;
        TInterface Resolve<TInterface>() where TInterface : class;

        void Dispose();
    }
}