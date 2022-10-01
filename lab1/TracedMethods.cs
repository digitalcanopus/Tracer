using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Library1;

namespace lab1
{
    public static class TracedMethods
    {
        public static void MSleep1()
        {
            Thread.Sleep(1000); 
        }

        public static void MSleep2()
        {
            Thread.Sleep(2000);
        }

        public static void SumArithmProgr1()
        {
            int sum = 0;
            for (int i = 0; i <= 100; i += 4)
                sum += i;
        }

        public static void SumArithmProgr2()
        {
            int sum = 0;
            for (int i = 0; i <= 1000; i += 4)
                sum += i;
        }

        public static MInfo TraceMethod1()
        {
            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.MSleep1));
            tracer.StartTrace();
            MSleep1();
            tracer.StopTrace();
            return new MInfo(tracer.GetTraceResult());
        }

        public static MInfo TraceMethod2()
        {
            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.MSleep2));
            tracer.StartTrace();
            MSleep2();
            tracer.StopTrace();
            return new MInfo(tracer.GetTraceResult());
        }

        public static MInfo TraceMethodInMethod()
        {
            var firstMethod = new MInfo();
            MInfo secondMethod = TraceMethod1();
            firstMethod.NestedMethods.Add(secondMethod);
            secondMethod = TraceMethod2();
            firstMethod.NestedMethods.Add(secondMethod);
            return firstMethod;
        }
    }
}
