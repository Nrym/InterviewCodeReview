using System;
using System.Configuration;
using LoggerFile;
using LoggerBean;

namespace LoggerLogic
{
    public class FileLogger : ILogger
    {
        string resultInfo = "";

        public bool LogMessage(string message, MessageType messageType)
        {
            bool result = false;
            
            try
            {
                message = DateTime.Now.ToLongTimeString() + " - " + messageType.ToString() + " - " + message;
                string filePath = ConfigurationManager.AppSettings["LogFileDirectory"];
                string fileName = "LogFile " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                FileMessage fileMessage = new FileMessage(message,filePath,fileName);
                LogMessageFile file = new LogMessageFile();

                result = file.WriteMessage(fileMessage);
                resultInfo = file.getResultInfo();
            }
            catch (Exception ex)
            {
                resultInfo = "FileLoggerException thrown: " + ex.Message;
            }
            return result;
        }

        public string getResultInfo()
        {
            return resultInfo;
        }
    }
}
