using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1
{
    public class MInfo
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public long Time { get; set; }
        public List<MInfo> NestedMethods { get; set; }

        public MInfo(string className, string methodName, long time)
        {
            ClassName = className;
            MethodName = methodName;
            Time = time;
            NestedMethods = new List<MInfo>();
        }

        public MInfo(TraceResult result)
        {
            ClassName = result.ClassName;
            MethodName = result.MethodName;
            Time = result.Time;
            NestedMethods = new List<MInfo>();
        }
    }
}
