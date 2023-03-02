using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Logging.Example
{
    public class TestOptionsMonitor : IOptionsMonitor<ConsoleLoggerOptions>
    {
        private ConsoleLoggerOptions _options;
        private event Action<ConsoleLoggerOptions, string> _onChange;

        public TestOptionsMonitor(ConsoleLoggerOptions options)
        {
            _options = options;
        }

        public ConsoleLoggerOptions Get(string name) => _options;

        public IDisposable OnChange(Action<ConsoleLoggerOptions, string> listener)
        {
            _onChange += listener;
            return null;
        }

        public ConsoleLoggerOptions CurrentValue => _options;

        public void Set(ConsoleLoggerOptions options)
        {
            _options = options;
            _onChange?.Invoke(options, "");
        }
    }
}
