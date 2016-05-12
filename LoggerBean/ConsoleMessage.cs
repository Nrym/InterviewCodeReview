using System;

namespace LoggerBean
{
    public class ConsoleMessage
    {
        public string message { get; set; }

        public ConsoleColor foregroundColor { get; set; }

        public ConsoleMessage(string message)
        {
            this.message = message;
            this.foregroundColor = Console.ForegroundColor;
        }

        public ConsoleMessage(string message, ConsoleColor foregroundColor)
        {
            this.message = message;
            this.foregroundColor = foregroundColor;
        }
    }
}
