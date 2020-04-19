using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Common
{
    public class DebugLog
    {
        public static void Log(string logEntry)
        {
            #if DEBUG
                Console.WriteLine (logEntry);
            #endif
        }
    }
}
