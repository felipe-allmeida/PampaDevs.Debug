using PampaDevs.Debug.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PampaDevs.Debug.Logger.Builder
{
    internal class DefaultLoggerBuilder : ILoggerBuilder
    {
        public void BuildLog(ELogType logType, string elapsedTime, string message)
        {
            var sb = new StringBuilder();

            sb.Append($"[{logType}]".PadRight(15, '.'));
            sb.Append($"{ elapsedTime }: {message}");

            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }

        public void BuildStackTrace(List<LogStackTrace> logStackTraces)
        {
            foreach (var log in logStackTraces)
            {
                var sb = new StringBuilder();

                sb.Append(log.Address.PadRight(70, '.'));

                sb.Append($"{ log.MethodName }(");

                for (int i = 0; i < log.Parameters.Count; i++)
                {
                    var parameter = log.Parameters[i];


                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(parameter);
                }

                sb.Append(')');

                System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
        }
    }
}
