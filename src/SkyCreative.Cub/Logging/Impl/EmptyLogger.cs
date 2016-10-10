using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Logging.Impl
{
    public class EmptyLogger:ILogger
    {
        public bool DebugEnabled
        {
            get { return false; }
        }

        public void Debug(object message, Exception ex = null)
        {
        }

        public void DebugFromat(string message, params object[] args)
        {
        }

        public void Info(object message)
        {
        }

        public void InfoFormat(string message, params object[] args)
        {
        }

        public void Warn(object message, Exception ex = null)
        {
        }

        public void WarnFormat(string message, params object[] args)
        {
        }

        public void Error(object message, Exception ex = null)
        {
        }

        public void ErrorFormat(string message, params object[] args)
        {
        }

        public void Fatal(object message, Exception ex = null)
        {
        }

        public void FatalFormat(string message, params object[] args)
        {
        }
    }
}
