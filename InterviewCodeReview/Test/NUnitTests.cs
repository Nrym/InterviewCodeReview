using System;
using System.Collections.Generic;
using NUnit.Framework;
using LoggerBean;

namespace InterviewCodeReview.Test
{
    [TestFixture]
    public class NUnitTests
    {
        //Set the variable true to print extra info of each Unit Test
        static bool printExtraInfo = true;

        [Test]
        public static void EmptyMessage()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = false;
            bool result = testLog.LogMessage(" ", MessageType.Error);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void NullMessage()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = false;
            bool result = testLog.LogMessage(null, MessageType.Error);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void NoMessageTypes()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = false;
            bool result = testLog.LogMessage("I'm never shown", MessageType.Warning);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void NoLogTypes()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = false;
            bool result = testLog.LogMessage("I'm never shown", MessageType.Warning);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void MessageTypeNotInConfigurationTypes()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = false;
            bool result = testLog.LogMessage("I'm never shown", MessageType.Warning);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void MessageToFile()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm a File Message", MessageType.Message);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void WarningToConsole()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.Console };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm a Console Warning", MessageType.Warning);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void ErrorToDatabase()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm a Database Error", MessageType.Error);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void MessageToDatabaseAndFile()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm a Database and File Message", MessageType.Message);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }


        [Test]
        public static void MessageToFileAndConsole()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm a File and Console Message", MessageType.Message);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void OnlyWarningsEverywhere()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Warning };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'll warn everyone. Winter is coming!", MessageType.Warning);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        [Test]
        public static void AllAllowedErrorEverywhere()
        {
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Message, MessageType.Warning, MessageType.Error };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };

            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);

            bool expected = true;
            bool result = testLog.LogMessage("I'm shown everywhere. Errors Everywhere!", MessageType.Error);

            Assert.AreEqual(expected, result);

            consoleInfoOutput(testLog.getMessageInfo());
        }

        private static void consoleInfoOutput(string message)
        {
            if (printExtraInfo)
            {
                ConsoleColor tmpColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + message + "\n");
                Console.ForegroundColor = tmpColor;
            }
        }
    }
}
