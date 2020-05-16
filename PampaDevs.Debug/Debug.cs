using System;
using System.Diagnostics;
using System.Reflection;

namespace PampaDevs.Debug
{
    public static class Debug
    {
        [IgnoreStackTrace]
        public static void Log(string message, bool showStackTrace = false)
        {
            Log(EDebugTypes.Log, message, showStackTrace);
        }

        [IgnoreStackTrace]
        public static void LogWarning(string message, bool showStackTrace = false)
        {
            Log(EDebugTypes.Warning, message, showStackTrace);
        }

        [IgnoreStackTrace]
        public static void LogError(string message, bool showStackTrace = false)
        {
            Log(EDebugTypes.Error, message, showStackTrace);
        }

        [IgnoreStackTrace]
        private static void Log(EDebugTypes debugTypes, string message, bool showStackTrace)
        {
            DebugLogType(debugTypes);
            DebugElapsedTime();
            DebugMessage(message);
            DebugEnd();

            if (showStackTrace)
            {
                DebugStackTrace();
            }
        }

        private static void DebugEnd()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DebugLogType(EDebugTypes debugTypes)
        {
            switch (debugTypes)
            {
                case EDebugTypes.Log:
                    Console.Write("[Log]".PadRight(15, '.'));
                    break;
                case EDebugTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[Warning]".PadRight(15, '.'));
                    break;
                case EDebugTypes.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[Error]".PadRight(15, '.'));
                    break;
            }            
        }

        private static void DebugElapsedTime()
        {
            Console.Write($"{GetElapsedTimeSinceApplicationStart()}");
        }

        private static string GetElapsedTimeSinceApplicationStart()
        {
            var elapsedTimeSinceStart = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            return $"({elapsedTimeSinceStart.Hours}:{elapsedTimeSinceStart.Minutes}:{elapsedTimeSinceStart.Seconds}:{elapsedTimeSinceStart.Milliseconds.ToString("00")}): ";
        }

        private static void DebugMessage(string message)
        {
            Console.WriteLine(message);
        }

        [IgnoreStackTrace]
        private static void DebugStackTrace()
        {
            StackTrace st = new StackTrace(true);
            var frames = st.GetFrames();

            var callingAssembly = Assembly.GetCallingAssembly().GetName().Name;

            foreach (var frame in frames)
            {
                Attribute attribute = GetIgnoreStackTraceAttribute(frame.GetMethod());

                if (attribute != null) continue;
                if (string.IsNullOrEmpty(frame.GetFileName())) break;

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write(GetLoggerAddress(callingAssembly, frame).PadRight(70, '.'));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(frame.GetMethod().Name);
                Console.ForegroundColor = ConsoleColor.White;
                
                DebugParameters(frame);
            }
        }

        private static void DebugParameters(StackFrame frame)
        {
            var parameters = frame.GetMethod().GetParameters();

            Console.Write("(");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }

                var typeWords = parameters[i].ParameterType.ToString().Split('.');

                for (int j = 0; j < typeWords.Length; j++)
                {
                    if (j > 0)
                    {
                        Console.Write('.');
                    }

                    if (j == typeWords.Length - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write(typeWords[j]);
                }

            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(")");
        }

        private static string GetLoggerAddress(string callingAssembly, StackFrame frame)
        {
            return $"{frame.GetFileName().Substring(frame.GetFileName().IndexOf(callingAssembly) + callingAssembly.Length + 1)}({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})";
        }

        private static Attribute GetIgnoreStackTraceAttribute(MethodBase method)
        {
            return Attribute.GetCustomAttribute(method, typeof(IgnoreStackTrace));
        }
    }

}
