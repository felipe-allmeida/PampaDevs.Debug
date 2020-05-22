using PampaDevs.Debug.DTOs;
using PampaDevs.Debug.Logger.Builder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PampaDevs.Debug.Logger
{
    sealed class Logger : ILogger
    {
        private Dictionary<ELoggerType, LoggerData> _dictLoggers = new Dictionary<ELoggerType, LoggerData>();
        public Logger()
        {
            InitializeLoggers();
        }

        private void InitializeLoggers()
        {
            _dictLoggers.Add(ELoggerType.Default, new LoggerData()
            {
                IsActive = true,
                LoggerType = ELoggerType.Default,
                Builder = new DefaultLoggerBuilder()
            });

            _dictLoggers.Add(ELoggerType.Console, new LoggerData()
            {
                IsActive = false,
                LoggerType = ELoggerType.Console,
                Builder = new ConsoleLoggerBuilder()
            });
        }

        public void EnableLogger(ELoggerType loggerType)
        {
            _dictLoggers[loggerType].IsActive = true;
        }

        public void DisableLogger(ELoggerType loggerType)
        {
            _dictLoggers[loggerType].IsActive = false;
        }

        public bool IsLoggerEnabled(ELoggerType loggerType)
        {
            return _dictLoggers[loggerType].IsActive;
        }

        [IgnoreStackTrace]
        public void Log(ELogType logType, string message, bool showStackTrace)
        {
            List<LogStackTrace> listStackTrace = null;

            if (showStackTrace)
            {
                listStackTrace = GetLogStackTrace();
            }

            foreach (var loggerData in _dictLoggers.Values)
            {
                if (loggerData.IsActive == false) continue;

                loggerData.Builder.BuildLog(logType, GetElapsedTimeSinceApplicationStart(), message);

                if (showStackTrace)
                {
                    loggerData.Builder.BuildStackTrace(listStackTrace);
                }
            }
        }

        private string GetElapsedTimeSinceApplicationStart()
        {
            var elapsedTimeSinceStart = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            return $"({elapsedTimeSinceStart.Hours}:{elapsedTimeSinceStart.Minutes}:{elapsedTimeSinceStart.Seconds}:{elapsedTimeSinceStart.Milliseconds.ToString("00")})";
        }

        [IgnoreStackTrace]
        private List<LogStackTrace> GetLogStackTrace()
        {
            var listLogStackTrace = new List<LogStackTrace>();

            StackTrace st = new StackTrace(true);
            var frames = st.GetFrames();

            var callingAssembly = Assembly.GetCallingAssembly().GetName().Name;

            foreach (var frame in frames)
            {
                if (MethodHasIgnoreStackTraceAttribute(frame.GetMethod())) continue;

                if (string.IsNullOrEmpty(frame.GetFileName())) break;

                var logStackTrace = new LogStackTrace();

                logStackTrace.Address = GetLoggerAddress(callingAssembly, frame);
                logStackTrace.MethodName = frame.GetMethod().Name;
                logStackTrace.Parameters = GetMethodParameters(frame.GetMethod());

                listLogStackTrace.Add(logStackTrace);
            }

            return listLogStackTrace;
        }

        private List<string> GetMethodParameters(MethodBase method)
        {
            return method.GetParameters()
                .Select(x => x.ParameterType.ToString()).ToList();
        }

        private static string GetLoggerAddress(string callingAssembly, StackFrame frame)
        {
            return $"{frame.GetFileName().Substring(frame.GetFileName().IndexOf(callingAssembly) + callingAssembly.Length + 1)}({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})";
        }

        private bool MethodHasIgnoreStackTraceAttribute(MethodBase method)
        {
            return Attribute.GetCustomAttribute(method, typeof(IgnoreStackTrace)) != null;
        }
    }
}
