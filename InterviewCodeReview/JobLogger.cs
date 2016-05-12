using System.Collections.Generic;
using LoggerBean;
using LoggerLogic;

namespace InterviewCodeReview
{
    public class JobLogger
    {
        private ICollection<MessageType> messageTypes;
        private ICollection<LogType> logTypes;
        private static LoggerFactory loggerFactory;
        private static ILogger logger;
        private string messageInfo = "";
        private int messageErrors = 0;
        private bool messageLogged = false;
        private bool initialized = false;

        public JobLogger(ICollection<MessageType> messageTypes, ICollection<LogType> logTypes)
        {
            this.messageTypes = messageTypes;
            this.logTypes = logTypes;
            loggerFactory = new LoggerFactory();
            initialized = true;
        }

        public bool LogMessage(string message, MessageType messageType)
        {
            messageInfo = "";
            messageErrors = 0;
            messageLogged = false;

            if (!initialized)
            {
                messageInfo = "Class wasn't initialized"; //Not possible since a compilation error would jump if the constructor isn't called
                return false;
            }

            if (message != null)
            {
                message = message.Trim();
                if (message.Length == 0)
                {
                    messageInfo = "Empty message was received";
                    return false;
                }
            }
            else
            {
                messageInfo = "Null message was received";
                return false;
            }

            if (logTypes.Count == 0)
            {
                messageInfo = "Invalid LogType Configuration, there must be at least one available LogType";
                return false;
            }

            if (messageTypes.Count == 0)
            {
                messageInfo = "Invalid MessageType Configuration, there must be at least one available MessageType";
                return false;
            }

            if (!messageTypes.Contains(messageType))
            {
                messageInfo = "Invalid MessageType Configuration, the messageType of the message isn't available in the current configuration";
                return false;
            }

            bool first = true;
            foreach(LogType type in logTypes)
            {
                logger = LoggerFactory.GetLogger(type);
                bool logResult = logger.LogMessage(message, messageType);
                messageLogged = messageLogged || logResult;
                if (!logResult)
                {
                    messageErrors++;
                }
                if (first)
                {
                    messageInfo += logger.getResultInfo();
                    first = false;
                }
                else
                {
                    messageInfo += "\n" + logger.getResultInfo();
                }
            }

            return messageLogged;
        }

        public string getMessageInfo()
        {
            return messageInfo;
        }

        public int getMessageErrors()
        {
            return messageErrors;
        }
    }
}