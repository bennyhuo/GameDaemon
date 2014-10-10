using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Item
{
    public class ActionItem
    {
        String[] actionList = {"禁用", "警告" };//暂时只支持禁用

        int startTimeValue;
        int endTimeValue;
        int actionValue = 0; 
        public String StartTime
        {
            get
            {
                return String.Format("{0:D2}:{1:D2}", startTimeValue / 60, startTimeValue % 60);
            }
        }

        public String EndTime
        {
            get
            {
                return String.Format("{0:D2}:{1:D2}",endTimeValue / 60, endTimeValue % 60);
            }
        }

        public String Action
        {
            get
            {
                return actionList[actionValue];
            }
        }

        public ActionItem(int startHour, int startMin, int endHour, int endMin)
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
