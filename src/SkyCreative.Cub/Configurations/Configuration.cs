using SkyCreative.Cub.Componts;
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

        public Configuration RegisterCommonComponts()
        {
            return this;
        }


    }
}
