using System;
using System.Collections.Generic;
using System.Text;

namespace PampaDevs.Debug.Logger
{
    internal interface ILogger
    {
        void EnableLogger(ELoggerType loggerType);
        void DisableLogger(ELoggerType loggerType);
        bool IsLoggerEnabled(ELoggerType loggerType);
        void Log(ELogType logType, string message, bool showStackTrace);
    }
}
