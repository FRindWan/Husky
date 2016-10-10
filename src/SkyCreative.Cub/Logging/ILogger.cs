using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Logging
{
    public interface ILogger
    {
        bool DebugEnabled { get; }

        void Debug(object message, Exception ex = null);

        void DebugFromat(string message, params object[] args);

        void Info(object message);

        void InfoFormat(string message, params object[] args);

        void Warn(object message, Exception ex=null);

        void WarnFormat(string message, params object[] args);

        void Error(object message, Exception ex = null);

        void ErrorFormat(string message, params object[] args);

        void Fatal(object message, Exception ex = null);

        void FatalFormat(string message, params object[] args);
    }
}
