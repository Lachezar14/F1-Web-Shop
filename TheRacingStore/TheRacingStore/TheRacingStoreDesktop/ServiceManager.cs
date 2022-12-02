using Microsoft.Extensions.DependencyInjection;
using Data_Layer.DBConnections;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRacingStoreDesktop
{
    public class ServiceManager
    {
        //This is done because if we have to change an implementation of a class, we only have to change it in one place.
        //This is what dependency injection is all about.
        public static IServiceProvider Get() //returns an object that implements IServiceProvider
        {
            //Service is a long-running application that can be started automatically when your system is started.You can pause and restart the service.
            var services = new ServiceCollection(); //list which contains all the services

            //Because managers classes have database classes interfaces passed in their constructors,when we get an object of a manager class,
            //we pass the database class object as well.
            //This singletons create only one object of managers that the program uses.

            //Singleton is a class which only allows a single instance of itself to be created,
            //and usually gives simple access to that instance.

            services.AddSingleton<IUserManager, UserManager>(); //whenever you need a object of type IUserManager, it will return an object of type UserManager.
            services.AddSingleton<IProductManager, ProductManager>();//whenever you need a object of type IProductManager, it will return an object of type ProductManager
            services.AddSingleton<IOrderManager, OrderManager>();//whenever you need a object of type IUserManager, it will return an object of type UserManager


            services.AddSingleton<IUserDB, UserDB>();//whenever you need a object of type IUserDB, it will return an object of type UserDB
            services.AddSingleton<IProductDB, ProductDB>();//whenever you need a object of type IProductDB, it will return an object of type ProductDB
            services.AddSingleton<IOrderDB, OrderDB>();//whenever you need a object of type IOrderDB, it will return an object of type OrderDB

            return services.BuildServiceProvider(); //returns a provider with configurations from above
        }
    }
}
