using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using SimpleChat.Infrastructure.Logger;

namespace SimpleChat.Messaging.Database.Sqlite.Tests
{
    [TestClass]
    public class NLogLoggerTests
    {
        const string LogPath = "c:\\";
        const string LogFileName = "log.txt";
        string LogFullPath = $"{LogPath}\\{LogFileName}";
        NLogLogger logger;

        [TestInitialize]
        public void Init()
        {
            logger = new NLogLogger(LogFullPath);
        }

        [TestMethod]
        public void CallMethods()
        {
            logger.Error("error message");
            logger.Info("info message");
            logger.Warn("warn message");

            StreamReader sr = new StreamReader(LogFullPath);
            var line = sr.ReadLine();
            while (line != null)
            {
                
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(LogFullPath))
                File.Delete(LogFullPath);
        }
    }
}
