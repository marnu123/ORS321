using ORSProject.file_handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ORSProject.error_handle
{
    public class ErrorHandler
    {
        private ErrorHandler() {  }

        private static ErrorHandler instance = new ErrorHandler();

        public static ErrorHandler getInstance()
        {
            return instance;
        }

        public void handle(Exception exception, bool writeToLog = false)
        {
            if (exception is OutOfMemoryException)
            {
                if (writeToLog == true)
                {
                    Writer writer = new Writer();
                    writer.writeLog(string.Format("OutOfMemoryException: {0} - {1}.txt", exception.ToString(), DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt")));
                }
                else
                {
                    Debug.WriteLine(exception.ToString());
                }

            }
            else
            {
                if (writeToLog == true)
                {
                    Writer writer = new Writer();
                    writer.writeLog(string.Format("Unknown: {0} - {1}.txt", exception.ToString(), DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt")));
                }
                else
                {
                    Debug.WriteLine(exception.ToString());
                }
            }
        }

        public void message(string mesasge, bool writeToLog = false)
        {
            if (writeToLog == true)
            {
                Writer writer = new Writer();
                writer.writeLog(string.Format("{0} - {1}.txt", mesasge, DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt")));
            }
            else
            {
                Debug.WriteLine(mesasge);
            }
        }


        public void messageAndExit(string mesasge)
        {
            Writer writer = new Writer();
            writer.writeLog(string.Format("{0} - {1}.txt", mesasge, DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt")));
            Console.WriteLine(mesasge);
            System.Threading.Thread.Sleep(4000);
            Environment.Exit(0);

        }

        public void writeToOutputTerminal(string message)
        {
            Debug.WriteLine(message);
        }

    }
}
