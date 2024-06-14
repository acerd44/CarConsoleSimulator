using Autofac;
using CarConsoleSimulator.Models;

namespace CarConsoleSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutoFacModule>();
            var container = builder.Build();
            container.Resolve<App>().Run();
        }
    }
}
