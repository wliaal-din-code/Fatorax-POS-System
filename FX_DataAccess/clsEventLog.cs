using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsEventLog
    {

        public static void LogOrCreateEventSoures(string Message)
        {
            string SoureName = "FatoraXApp";

            if (!EventLog.SourceExists(SoureName))
            {
                EventLog.CreateEventSource(SoureName, "Application");
            }

            EventLog.WriteEntry(SoureName, Message, EventLogEntryType.Error);

        }
    }
}
