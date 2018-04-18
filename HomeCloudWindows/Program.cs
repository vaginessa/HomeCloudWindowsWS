using System.ServiceProcess;

namespace HomeCloudWindows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HomeCloudService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
