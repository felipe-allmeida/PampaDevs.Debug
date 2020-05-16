using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace PampaDevs.Debug.Tests
{
    public class DebugTests
    {
        [Fact]
        public void Log_WhenLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.Log("teste");

            Assert.Matches(@"^\[Log\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void Log_WhenWarningLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogWarning("teste");

            Assert.Matches(@"^\[Warning\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void Log_WhenErrorLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogError("teste");

            Assert.Matches(@"^\[Error\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void Log_WhenLog_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.Log("teste", true);

            Assert.Matches(new Regex(@"^\[Log\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+Log_WhenLog_AndStackTraceEnable_ShouldOutputToConsole\(\)"), stringWriter.ToString());
        }

        [Fact]
        public void Log_WhenLogWarning_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogWarning("teste", true);

            Assert.Matches(new Regex(@"^\[Warning\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+Log_WhenLogWarning_AndStackTraceEnable_ShouldOutputToConsole\(\)"), stringWriter.ToString());
        }

        [Fact]
        public void Log_WhenLogError_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogError("teste", true);

            Assert.Matches(new Regex(@"^\[Error\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+Log_WhenLogError_AndStackTraceEnable_ShouldOutputToConsole\(\)"), stringWriter.ToString());
        }
    }
}
