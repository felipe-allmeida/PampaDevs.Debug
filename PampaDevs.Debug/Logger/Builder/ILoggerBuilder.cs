using PampaDevs.Debug.DTOs;
using System.Collections.Generic;

namespace PampaDevs.Debug.Logger.Builder
{
    internal interface ILoggerBuilder
    {
        void BuildLog(ELogType logType, string elapsedTime, string message);
        void BuildStackTrace(List<LogStackTrace> logStackTraces);
    }
}
