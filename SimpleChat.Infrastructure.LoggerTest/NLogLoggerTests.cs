using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using SimpleChat.Infrastructure.Logger;

namespace SimpleChat.Infrastructure.LoggerTest
{
    [TestClass]
    public class NLogLoggerTests
    {
        static string LogPath = Directory.GetCurrentDirectory();
        static string LogFileName = "log.log";
        string LogFullPath = $"{LogPath}\\{LogFileName}";
        NLogLogger logger;

        [TestInitialize]
        public void Init()
        {
            if (File.Exists(LogFullPath))
                File.Delete(LogFullPath);
            logger = new NLogLogger(LogFullPath);
        }

        [TestMethod]
        public void TestError()
        {
            logger.Error("error message");

            StreamReader sr = new StreamReader(LogFullPath);
            string line;
            var check = false;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("error message"))
                {
                    check = true;
                    break;
                }
                
            }
            Assert.IsTrue(check);
            sr.Close();
        }

        [TestMethod]
        public void TestErrorEx()
        {
            Exception e = new Exception();
            logger.Error(e, "error message");

            StreamReader sr = new StreamReader(LogFullPath);
            string line;
            var check = false;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("error message"))
                {
                    check = true;
                    break;
                }
            }
            Assert.IsTrue(check);
            sr.Close();
        }

        [TestMethod]
        public void TestWarn()
        {
            logger.Warn("warn message");

            StreamReader sr = new StreamReader(LogFullPath);
            var line = sr.ReadLine();
            var check = false;
            while (line != null)
            {
                if (line.Contains("warn message"))
                {
                    check = true;
                    break;
                }
            }
            Assert.IsTrue(check);
            sr.Close();
        }

        [TestMethod]
        public void TestInfo()
        {
            logger.Error("info message");

            StreamReader sr = new StreamReader(LogFullPath);
            var line = sr.ReadLine();
            var check = false;
            while (line != null)
            {
                if (line.Contains("info message"))
                {
                    check = true;
                    break;
                }
            }
            Assert.IsTrue(check);
            sr.Close();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(LogFullPath))
                File.Delete(LogFullPath);
        }
    }
}
