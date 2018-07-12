using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SimpleChat.Infrastructure.Logger
{
    public class NLogLogger : ILogger
    {
        const string LoggerName = "SimpleChatLogger";
        readonly NLog.Logger logger;
        public NLogLogger(string directory)
        {
            logger = LogManager.GetLogger(LoggerName);
            var config = new LoggingConfiguration();
            var logfile = new FileTarget("logfile") { FileName = directory };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception e, string message)
        {
            logger.Error(e, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}
