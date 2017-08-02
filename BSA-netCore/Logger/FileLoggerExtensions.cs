using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BSA_netCore.Logger
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFileLogger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new FileLoggerProvider(new FileLoggerConfig()));
            return loggerFactory;
        }

        public static ILoggerFactory AddFileLogger(this ILoggerFactory loggerFactory, FileLoggerConfig config)
        {
            loggerFactory.AddProvider(new FileLoggerProvider(config));
            return loggerFactory;
        }

        public static ILoggerFactory AddFileLogger(this ILoggerFactory loggerFactory,
            Action<FileLoggerConfig> configure)
        {
            var config = new FileLoggerConfig();
            configure(config);
            loggerFactory.AddProvider(new FileLoggerProvider(config));
            return loggerFactory;
        }
    }
}
