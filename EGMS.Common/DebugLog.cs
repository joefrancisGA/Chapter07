using System;

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
