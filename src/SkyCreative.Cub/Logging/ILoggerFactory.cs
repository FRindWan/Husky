using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create(Type type);

        ILogger Create<TService>();

        ILogger Create(string name);
    }
}
