using System;
using System.Collections.Generic;
using LoggerBean;

namespace InterviewCodeReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nestor Mancilla Valverde");
            Console.WriteLine("May 11, 2016\n");
            Console.WriteLine("Interview Code Review");
            Console.WriteLine("Belatrix Software\n");
            Console.WriteLine("Using NUnit v2.63 for the Unit Tests, NUnit GUI tool available for this version");

            //Local Test Code, use for project setup
            //This code will print errors that help the user configure the project
            /*
            ICollection<MessageType> allMessageTypes = new List<MessageType> { MessageType.Warning };
            ICollection<LogType> allLogTypes = new List<LogType> { LogType.File, LogType.Console, LogType.Database };
            JobLogger testLog = new JobLogger(allMessageTypes, allLogTypes);
            bool result = testLog.LogMessage("I'll warn everyone. Winter is coming!", MessageType.Warning);
            Console.WriteLine(testLog.getMessageInfo());
            */

            Console.WriteLine("\n\n\nPress enter to exit..");
            Console.ReadLine();
        }
    }
}
