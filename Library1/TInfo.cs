using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class TInfo
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public List<MInfo> MethodsInfList { get; set; }

        public TInfo(int id, long time)
        {
            Id = id;
            Time = time;
            MethodsInfList = new List<MInfo>();
        }

        public TInfo()
        {
            MethodsInfList = new List<MInfo>();
        }

        //add inf about method in thread
        public void MethodInfAdd(MInfo mInfo)
        {
            MethodsInfList.Add(mInfo);
        }
    }
}
