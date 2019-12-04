using System;
using System.Diagnostics;

namespace EventLogWriting
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "Demo Source";
            String[] arguments = Environment.GetCommandLineArgs();
            Console.WriteLine("GetCommandLineArgs: {0}", String.Join(", ", arguments));
            EventLog eventLog = new EventLog("Application");
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
            eventLog.Source = "App2";

            foreach (string EventID in arguments)
            {
                int EventNumber;
                Int32.TryParse(EventID, out EventNumber);
                eventLog.WriteEntry("Hello, event log!", EventLogEntryType.Error, EventNumber);
            }
        }
    }
}
