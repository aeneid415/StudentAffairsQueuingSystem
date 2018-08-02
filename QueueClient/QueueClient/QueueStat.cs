using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueClient
{
    public class QueueStat
    {
        int cubicle_number;
        int serving_number;
        DateTime timestamp;
        int ActivationFlag;

        public QueueStat()
        {

        }

        public QueueStat(int n, int s)
        {
            this.cubicle_number = n;
            this.serving_number = s;
        }

        public QueueStat(int n, int s, int fl)
        {
            this.cubicle_number = n;
            this.serving_number = s;
            this.ActivationFlag = fl;
        }

        public QueueStat(int n, int s, DateTime t)
        {
            this.cubicle_number = n;
            this.serving_number = s;
            this.timestamp = t;
        }

       

        public int getCubicleNumber()
        {
            return this.cubicle_number;
        }

        public int getServingNumber()
        {
            return this.serving_number;
        }

        public DateTime getTimeStamp()
        {
            return this.timestamp;
        }

        public int getFlag()
        {
            return this.ActivationFlag;
        }
    }
}
