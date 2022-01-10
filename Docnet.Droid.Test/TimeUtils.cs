using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinCommon.Tools
{
    public class TimeUtils
    {
        static public long CurrentSystemTimeMillis
        {
            get
            {
                TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
                long millis = (long)ts.TotalMilliseconds;
                return millis;
            }  
        }
    }
}
