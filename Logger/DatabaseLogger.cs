using System;
using LoggerBean;
using LoggerData;

namespace LoggerLogic
{
    public class DatabaseLogger : ILogger
    {
        string format = "yyyy-MM-dd HH:mm:ss";
        string resultInfo = "";

        public bool LogMessage(string message, MessageType messageType)
        {
            bool result = false;
            int type;

            try
            {
                switch (messageType)
                {
                    case MessageType.Message:
                        type = 1;
                        break;
                    case MessageType.Error:
                        type = 2;
                        break;
                    default:
                        type = 3;
                        break;
                }

                DataMessage dataMessage = new DataMessage(message, type, DateTime.Now.ToString(format));
                LogMessageData data = new LogMessageData();

                result = data.insertLogMessage(dataMessage);

                resultInfo = data.getResultInfo();
            }
            catch (Exception ex)
            {
                resultInfo = "DatabaseLoggerException thrown: " + ex.Message;
            }
            return result;
        }

        public string getResultInfo()
        {
            return resultInfo;
        }
    }
}
