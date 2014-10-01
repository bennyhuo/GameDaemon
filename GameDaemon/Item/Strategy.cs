using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Item
{
    class Strategy
    {
        List<TimeBlock> timeList;
        bool isWhiteListMode = false;

        public Strategy()
        {
            timeList = new List<TimeBlock>();
        }

        public bool isAvailable()
        {
            //根据当前时间判断是否与时间区间吻合，给出是否能够运行。
            bool isInBlocks = false;
            DateTime time = DateTime.Now;
            foreach (TimeBlock block in timeList)
            {
                isInBlocks = block.isInBlock(time);
                if (isInBlocks)
                {
                    break;
                }
            }
           /**
            * 1  in white true  t t
            * 2  out white false f t
            * 3  in black false t f
            * 4  out black true f f
            * */
            return isInBlocks == isWhiteListMode;
        }

        public void addTimeBlock(TimeBlock block)
        {
            timeList.Add(block);
        }

        public void rmTimeBlock(TimeBlock block)
        {
            timeList.Remove(block);
        }
    }
}
