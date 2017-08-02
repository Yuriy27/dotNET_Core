using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BSA_netCore.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _name;

        private readonly FileLoggerConfig _config;

        public FileLogger(string name, FileLoggerConfig config)
        {
            _name = name;
            _config = config;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                if (_config.EventId == 0 || _config.EventId == eventId.Id)
                {
                    using (var writer = File.AppendText(_config.FilePath))
                    {
                        writer.WriteLine($"[{DateTime.Now}] {logLevel} - {eventId.Id} - {_name} - {formatter(state, exception)}");
                    }
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
