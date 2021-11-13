using ConsoleApp1.Services;
using Ninject;

namespace ConsoleApp1.Infrastructure
{
    internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<IAlertTemplate>().To<AlertTemplate>();
           // Kernel.Bind<IService>().To<Service>();
        }

        public static T Resolve<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
