namespace Shop_Product_Parser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            new ParserService().OnDebug();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ParserService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
