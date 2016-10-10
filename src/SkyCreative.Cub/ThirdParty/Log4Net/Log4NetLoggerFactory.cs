using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using SkyCreative.Cub.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.ThirdParty.Log4Net
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public Log4NetLoggerFactory(string configFilePath)
        {
            FileInfo configFile = new FileInfo(configFilePath);
            if (!configFile.Exists)
            {
                configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFilePath));
            }

            if (configFile.Exists)
            {
                XmlConfigurator.ConfigureAndWatch(configFile);
            }
            else
            {
                BasicConfigurator.Configure(new ConsoleAppender{ Layout= new PatternLayout() });
            }
        }

        public ILogger Create(string name)
        {
            return new Log4NetLogger(LogManager.GetLogger(name));
        }

        public ILogger Create(Type type)
        {
            return new Log4NetLogger(LogManager.GetLogger(type.FullName));
        }

        public ILogger Create<TService>()
        {
            return new Log4NetLogger(LogManager.GetLogger(typeof(TService).FullName));
        }
    }
}
