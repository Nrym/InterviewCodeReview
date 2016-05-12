using LoggerBean;

namespace LoggerLogic
{
    public class LoggerFactory
    {
        public static ILogger GetLogger(LogType type)
        {
            switch (type)
            {
                case LogType.File:
                    return new FileLogger();
                case LogType.Console:
                    return new ConsoleLogger();
                default:
                    return new DatabaseLogger();
            }
        }
    }
}
