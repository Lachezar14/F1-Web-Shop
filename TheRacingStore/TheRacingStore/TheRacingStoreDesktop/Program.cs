using Logic_Layer.Interfaces;
using Logic_Layer.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace TheRacingStoreDesktop
{
    internal static class Program
    {
        private static readonly IServiceProvider _provider = ServiceManager.Get(); //gets an instance of the IServiceProvider and gets the list of services.
        [STAThread]
        static void Main()
        {
            //service is a implementation
            var productManager = _provider.GetService<IProductManager>(); //return the implementation of the IProductManager, which is a implementation of ProductManager.
            var userManager = _provider.GetService<IUserManager>();//return the implementation of the IUserManager, which is a implementation of UserManager.
            var orderManager = _provider.GetService<IOrderManager>();//return the implementation of the IOrderManager, which is a implementation of OrderManager.

            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(userManager, productManager, orderManager));//the application gets all manager object implementations
                                                                                  //with the database classes implementation in the constructor
                                                                                  //of the manager classes
                                                                                  //matrioshki
        }
    }
}