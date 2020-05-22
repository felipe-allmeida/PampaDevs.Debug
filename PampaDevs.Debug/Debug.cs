using PampaDevs.Debug.Logger;
using System;
using System.Diagnostics;
using System.Reflection;

namespace PampaDevs.Debug
{
    public static partial class Debug
    {
        private static readonly ILogger _logger;
        static Debug()
        {
            _logger = new Logger.Logger();
        }

        [IgnoreStackTrace]
        public static void Log(string message, bool showStackTrace = false)
        {
            _logger.Log(ELogType.Log, message, showStackTrace);
        }

        [IgnoreStackTrace]
        public static void LogWarning(string message, bool showStackTrace = false)
        {
            _logger.Log(ELogType.Warning, message, showStackTrace);
        }

        [IgnoreStackTrace]
        public static void LogError(string message, bool showStackTrace = false)
        {
            _logger.Log(ELogType.Error, message, showStackTrace);
        }

        public static bool DefaultLoggerEnabled
        {
            get
            {
                return _logger.IsLoggerEnabled(ELoggerType.Default);
            }
            set
            {
                if (value) _logger.EnableLogger(ELoggerType.Default);
                else _logger.DisableLogger(ELoggerType.Default);
            }
        }

        public static bool ConsoleLoggerEnabled
        {
            get
            {
                return _logger.IsLoggerEnabled(ELoggerType.Console);
            }
            set
            {
                if (value) _logger.EnableLogger(ELoggerType.Console);
                else _logger.DisableLogger(ELoggerType.Console);
            }
        }
    }
}
