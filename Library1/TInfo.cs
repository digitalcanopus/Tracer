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
        public List<MInfo> MetInfList { get; set; }

        public TInfo(int id, long time)
        {
            Id = id;
            Time = time;
            MetInfList = new List<MInfo>();
        }
    }
}
