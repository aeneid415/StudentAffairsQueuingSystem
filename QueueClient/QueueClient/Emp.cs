using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueClient
{
    class Emp
    {
        public static int empId;
        public static string IPAddress = null;

        public int getEmpID()
        {
            return empId;
        }

        public String GetIPAddress()
        {
            return IPAddress;
        }

        public void SetIPAddress(String ip)
        {
            IPAddress = ip;
        }
    }
}
