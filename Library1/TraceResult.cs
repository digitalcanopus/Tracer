using System;

namespace Library1
{
    public class TraceResult
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public long Time { get; set; }

        public TraceResult(string className, string methodName, long time)
        {
            ClassName = className;
            MethodName = methodName;
            Time = time;
        }

    }

}
