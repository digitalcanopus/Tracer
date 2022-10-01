using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Library1
{
    public class Tracer : ITracer
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public long Time { get; set; }
        private Stopwatch Clock1 { get; set; }

        public Tracer(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
            Clock1 = new Stopwatch();
        }

        public void StartTrace()
        {
            Clock1.Start();
        }

        public void StopTrace()
        {
            Clock1.Stop();
            Time = Clock1.ElapsedTicks;
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(ClassName, MethodName, Time);
        }
    }
}
