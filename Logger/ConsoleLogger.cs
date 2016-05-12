using System;
using LoggerConsole;
using LoggerBean;

namespace LoggerLogic
{
    public class ConsoleLogger : ILogger
    {
        string resultInfo = "";

        public bool LogMessage(string message, MessageType messageType)
        {
            bool result = false;

            try
            {
                ConsoleMessage consoleMessage = new ConsoleMessage(DateTime.Now.ToString() + " - " + messageType.ToString() + " - " + message);

                switch (messageType)
                {
                    case MessageType.Message:
                        consoleMessage.foregroundColor = ConsoleColor.White;
                        break;
                    case MessageType.Warning:
                        consoleMessage.foregroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        consoleMessage.foregroundColor = ConsoleColor.Red;
                        break;
                }

                LogMessageConsole console = new LogMessageConsole();

                result = console.printConsoleMessage(consoleMessage);
                resultInfo = console.getResultInfo();
            }
            catch(Exception ex)
            {
                resultInfo = "ConsoleLoggerException thrown: " + ex.Message;
            }

            return result;
        }

        public string getResultInfo()
        {
            return resultInfo;
        }
    }
}
