namespace ioc_container
{
    public class Tester : ITester
    {
        private ILogger _logger;
        public Tester(ILogger logger)
        {
            _logger = logger;
        }

        public void CompleteTest(string message)
        {
            _logger.PrintMessage(message);
        }
    }
}