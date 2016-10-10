using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Logging.Impl
{
    public class EmptyLoggerFactory:ILoggerFactory
    {
        private static readonly EmptyLogger emptyLogger = new EmptyLogger();

        public ILogger Create(Type type)
        {
            return emptyLogger;
        }

        public ILogger Create<TService>()
        {
            return emptyLogger;
        }

        public ILogger Create(string name)
        {
            return emptyLogger;
        }
    }
}
