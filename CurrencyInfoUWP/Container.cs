using Autofac;

using CurrencyInfoUWP.ViewModels;
using Shared.Services;
using Shared.Services.Rates;
using Shared.Services.DataProvider;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyInfoUWP
{
    // Provides IoC logic for the application
    public sealed class Container
    {
        private static IContainer container;

        private Container() { }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DirectApiService>().As<IDataProviderService>();
            builder.RegisterType<RatesService>().As<IRatesService>();
            builder.RegisterType<MainPageViewModel>().InstancePerLifetimeScope();

            return builder.Build();
        }

        public static IContainer GetContainer()
        {
            if (container == null)
                container = ConfigureContainer();
            return container;
        }
    }
}
