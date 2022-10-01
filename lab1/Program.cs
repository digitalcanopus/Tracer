using System;
using System.Threading;
using System.Diagnostics;

using Library1;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        public static List<TInfo> ThrInfList = new List<TInfo>();

        public static void Thread1()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();

            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.FirstMethod));
            tracer.StartTrace();
            TracedMethods.FirstMethod();
            tracer.StopTrace();
            TraceResult result = tracer.GetTraceResult();

            clock.Stop();

            TInfo tinfo = new TInfo(Thread.CurrentThread.ManagedThreadId, clock.ElapsedTicks);
            MInfo minfo = new MInfo(result);
            tinfo.MethodsInfList.Add(minfo);
            ThrInfList.Add(tinfo);

            Console.WriteLine("1");
            Thread.Sleep(1000);
        }

        public static void Thread2()
        {
            Console.WriteLine("2");
            Thread.Sleep(1000);
        }

        public static void Thread3()
        {
            Console.WriteLine("3");
            Thread.Sleep(1000);
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Thread1);
            Thread t2 = new Thread(Thread2);
            Thread t3 = new Thread(Thread3);
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

        }
    }
}
