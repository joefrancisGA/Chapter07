using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Common
{
    class DebugLog
    {
        public void Log(string logEntry)
        {
            #if DEBUG
                Console.WriteLine (logEntry);
            #endif
        }
    }
}
