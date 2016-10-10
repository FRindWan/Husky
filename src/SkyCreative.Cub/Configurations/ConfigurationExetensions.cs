using Autofac;
using SkyCreative.Cub.Components;
using SkyCreative.Cub.Logging;
using SkyCreative.Cub.ThirdParty.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Configurations
{
    public static class ConfigurationExetensions
    {
        public static Configuration UseAutofac(this Configuration configuration)
        {
            Container.SetContainer(new ThirdParty.Autofacs.AutofacContainer());

            return configuration;
        }

        public static Configuration UseAutofac(this Configuration configuration,ContainerBuilder builder)
        {
            Container.SetContainer(new ThirdParty.Autofacs.AutofacContainer(builder));

            return configuration;
        }

        public static Configuration UseLog4Net(this Configuration configuration)
        {
            UseLog4Net(configuration, "log4net.config");

            return configuration;
        }

        public static Configuration UseLog4Net(this Configuration configuration,string configFilePath)
        {
            configuration.SetDefault<ILoggerFactory, Log4NetLoggerFactory>(new Log4NetLoggerFactory(configFilePath));

            return configuration;
        }
    }
}
