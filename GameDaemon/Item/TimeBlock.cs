using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Item
{
    class TimeBlock
    {
        int startTimeValue;
        int endTimeValue;

        public TimeBlock(int startHour, int startMin, int endHour, int endMin)
        {
            this.startTimeValue = startHour * 60 + startMin;
            this.endTimeValue = endHour * 60 + endMin;
        }

        public bool isInBlock(DateTime time)
        {
            int curHour = time.Hour;
            int curMin = time.Minute;
            int curTimeValue = curHour * 60 + curMin;
            if (curTimeValue < endTimeValue && curTimeValue > startTimeValue)
            {
                return true;
            }
            return false;
        }
    }
}
