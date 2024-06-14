using Autofac;
using CarConsoleSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Models
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<App>().AsSelf().SingleInstance();
            builder.RegisterType<Simulator>().As<ISimulator>().SingleInstance();
            builder.RegisterType<PersonService>().As<IPersonService>().SingleInstance();
        }
    }
}
