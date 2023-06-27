namespace ioc_container
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iocContainer = new IocContainer();

            iocContainer.Register<ILogger, Logger>();
            iocContainer.Register<ITester, Tester>();

            var tester = iocContainer.Resolve<ITester>();
            tester.CompleteTest("Hello");          
        }
    }
}