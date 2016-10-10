using log4net;
using SkyCreative.Cub.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.ThirdParty.Log4Net
{
    public class Log4NetLogger:ILogger
    {
        private readonly ILog _log;

        public Log4NetLogger(ILog log)
        {
            _log = log;
        }

        public bool DebugEnabled
        {
            get
            {
                return _log.IsDebugEnabled;
            }
        }

        public void Debug(object message, Exception ex = null)
        {
            _log.Debug(message, ex);
        }

        public void DebugFromat(string message, params object[] args)
        {
            _log.DebugFormat(message, args);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void InfoFormat(string message, params object[] args)
        {
            _log.InfoFormat(message, args);
        }

        public void Warn(object message, Exception ex = null)
        {
            _log.Warn(message, ex);
        }

        public void WarnFormat(string message, params object[] args)
        {
            _log.WarnFormat(message, args);
        }

        public void Error(object message, Exception ex = null)
        {
            _log.Error(message, ex);
        }

        public void ErrorFormat(string message, params object[] args)
        {
            _log.ErrorFormat(message, args);
        }

        public void Fatal(object message, Exception ex = null)
        {
            _log.Fatal(message, ex);
        }

        public void FatalFormat(string message, params object[] args)
        {
            _log.FatalFormat(message, args);
        }
    }
}
