using LoggerBean;

namespace LoggerLogic
{
    public interface ILogger
    {
        bool LogMessage(string message, MessageType messageType);
        string getResultInfo();
    }
}