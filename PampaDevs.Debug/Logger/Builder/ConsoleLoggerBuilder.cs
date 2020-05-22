using PampaDevs.Debug.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PampaDevs.Debug.Logger.Builder
{
    internal class ConsoleLoggerBuilder : ILoggerBuilder
    {
        public void BuildLog(ELogType logType, string elapsedTime, string message)
        {
            SetConsoleColorFor(logType);

            Console.Write($"[{logType}]".PadRight(15, '.'));
            Console.Write(elapsedTime);
            Console.WriteLine($": {message}");

            ResetConsoleColor();
        }

        public void BuildStackTrace(List<LogStackTrace> logStackTraces)
        {
            foreach(var log in logStackTraces)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(log.Address.PadRight(70, '.'));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(log.MethodName);

                ResetConsoleColor();
                Console.Write('(');
                                
                for(int i = 0; i < log.Parameters.Count; i ++)
                {
                    var parameter = log.Parameters[i];

                    var index = parameter.LastIndexOf('.');

                    var typeSuffix = parameter.Substring(0, index);
                    var type = parameter.Substring(index);

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    if (i > 0)
                    {
                        Console.Write(", ");
                    }

                    Console.Write($"{typeSuffix}.");

                    ResetConsoleColor();

                    Console.Write(type);
                }

                ResetConsoleColor();
                Console.WriteLine(')');
            }
        }

        private void SetConsoleColorFor(ELogType logType)
        {
            switch (logType)
            {
                case ELogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ELogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
        
        private void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
