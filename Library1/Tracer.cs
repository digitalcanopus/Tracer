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
        private Stopwatch Clock { get; set; }

        public Tracer(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
            Clock = new Stopwatch();
        }

        public Tracer()
        {
            Clock = new Stopwatch();
        }

        public void StartTrace()
        {
            Clock.Start();
        }

        public void StopTrace()
        {
            Clock.Stop();
            Time = Clock.ElapsedTicks;
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(ClassName, MethodName, Time);
        }
    }
}
