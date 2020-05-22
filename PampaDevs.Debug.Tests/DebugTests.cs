using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace PampaDevs.Debug.Tests
{
    public class DebugTests
    {
        public DebugTests()
        {
            Debug.ConsoleLoggerEnabled = true;
        }

        [Fact]
        public void Log_WhenEnableConsoleLogger_ShouldReturnEnabledConsoleLogger()
        {
            Debug.ConsoleLoggerEnabled = true;
            Assert.True(Debug.ConsoleLoggerEnabled);
        }

        [Fact]
        public void Log_WhenDisableConsoleLogger_ShouldReturnDisabledConsoleLogger()
        {
            Debug.ConsoleLoggerEnabled = false;
            Assert.False(Debug.ConsoleLoggerEnabled);
        }

        [Fact]
        public void Log_WhenConsoleLoggerDisabled_ShouldNotOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.ConsoleLoggerEnabled = false;

            Debug.Log("teste");

            Assert.Empty(stringWriter.ToString());

            Debug.ConsoleLoggerEnabled = true;
        }

        [Fact]
        public void ConsoleLog_WhenConsoleLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.Log("teste");

            Assert.Matches(@"^\[Log\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void ConsoleLog_WhenWarningConsoleLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogWarning("teste");

            Assert.Matches(@"^\[Warning\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void ConsoleLog_WhenErrorConsoleLog_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogError("teste");

            Assert.Matches(@"^\[Error\]\.+\(\d+:\d+:\d+:\d+\): teste", stringWriter.ToString());
        }

        [Fact]
        public void ConsoleLog_WhenConsoleLog_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.Log("teste", true);

            Assert.Matches(new Regex(@"^\[Log\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+ConsoleLog_WhenConsoleLog_AndStackTraceEnable_ShouldOutputToConsole\(\)"), stringWriter.ToString());
        }

        [Fact]
        public void ConsoleLog_WhenLogWarning_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogWarning("teste", true);

            Assert.Matches(new Regex(@"^\[Warning\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+ConsoleLog_WhenLogWarning_AndStackTraceEnable_ShouldOutputToConsole\(\)"), stringWriter.ToString());
        }

        [Fact]
        public void ConsoleLog_WhenLogError_AndStackTraceEnable_ShouldOutputToConsole()
        {
            using var stringWriter = new StringWriter();

            Console.SetOut(stringWriter);

            Debug.LogError("teste", true);
            var log = stringWriter.ToString();
            Assert.Matches(new Regex(@"^\[Error\]\.+\(\d+:\d+:\d+:\d+\): teste\s+[\w\.\\]+\(\d+, \d+\)\.+ConsoleLog_WhenLogError_AndStackTraceEnable_ShouldOutputToConsole\(\)"), log);
        }
    }
}
