using SkyCreative.Cub.Components;
using SkyCreative.Cub.Logging;
using SkyCreative.Cub.Logging.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Configurations
{
    public class Configuration
    {
        public readonly static Configuration Instance = new Configuration();

        private Configuration()
        { 
        
        }

        public Configuration SetDefault<TInterface, TService>(LifeScope lifeScope = LifeScope.Transient)where TService:TInterface
        {
            Container.Current.Register<TInterface, TService>(lifeScope);

            return this;
        }

        public Configuration SetDefault<TInterface, TService>(TService instance, string serviceName = null)
            where TService:class,TInterface
        {
            Container.Current.RegisterInstance<TInterface, TService>(instance, serviceName);

            return this;
        }

        public Configuration RegisterCommonComponents()
        {
            this.SetDefault<ILoggerFactory, EmptyLoggerFactory>(LifeScope.Single);

            return this;
        }

        public Configuration RegisterUnHandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Container.Current.Resolver<ILoggerFactory>().Create(this.GetType()).ErrorFormat("unhandled exception:{0}", e.ExceptionObject);
            };

            return this;
        }
    }
}
