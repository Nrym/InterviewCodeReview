using System;
using LoggerBean;

namespace LoggerConsole
{
    public class LogMessageConsole
    {
        private string resultInfo = "";

        public bool printConsoleMessage(ConsoleMessage consoleMessage)
        {
            bool result = false;

            try
            {

                ConsoleColor tmpColor = Console.ForegroundColor;

                Console.ForegroundColor = consoleMessage.foregroundColor;

                Console.WriteLine(consoleMessage.message);

                Console.ForegroundColor = tmpColor;

                result = true;
                resultInfo = "Written to console succesfully";
            }
            catch (Exception ex)
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
