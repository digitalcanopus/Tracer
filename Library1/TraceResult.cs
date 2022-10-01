using System;

namespace Library1
{
    public class TraceResult
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public long Time { get; set; }

       //result struct
        public TraceResult(string className, string methodName, long time)
        {
            ClassName = className;
            MethodName = methodName;
            Time = time;
        }

        public void TracePrint()
        {
            Console.Write(ClassName + ".");
            Console.Write(MethodName + ": ");
            Console.WriteLine(Time);
        }
    }
}
