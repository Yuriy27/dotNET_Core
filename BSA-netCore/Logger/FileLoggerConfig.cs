using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BSA_netCore.Logger
{
    public class FileLoggerConfig
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public int EventId { get; set; } = 0;

        public string FilePath { get; set; } = "logs.log";
    }
}
