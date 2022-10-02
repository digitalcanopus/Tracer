using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text;

using Library1;

namespace lab1
{
    class Program
    {
        public static List<TInfo> ThrInfList = new List<TInfo>();

        public static TracedMethods tm = new TracedMethods();

        public static void Thread1()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();

            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.MSleep1));
            tracer.StartTrace();
            TracedMethods.MSleep1();
            tracer.StopTrace();
            TraceResult result = tracer.GetTraceResult();

            clock.Stop();

            TInfo tinfo = new TInfo(Thread.CurrentThread.ManagedThreadId, clock.ElapsedTicks);
            MInfo minfo = new MInfo(result);
            tinfo.MethodsInfList.Add(minfo);
            ThrInfList.Add(tinfo);

            //Console.WriteLine("1");
            //Thread.Sleep(1000);
        }

        public static void Thread2()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();

            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.MSleep2));
            tracer.StartTrace();
            TracedMethods.MSleep2();
            tracer.StopTrace();
            TraceResult result = tracer.GetTraceResult();

            clock.Stop();

            TInfo tinfo = new TInfo(Thread.CurrentThread.ManagedThreadId, clock.ElapsedTicks);
            MInfo minfo = new MInfo(result);
            tinfo.MethodsInfList.Add(minfo);
            ThrInfList.Add(tinfo);

            //Console.WriteLine("2");
            //Thread.Sleep(1000);
        }

        public static void MethodMain()
        {
            Thread.Sleep(5000);
        }

        public static void Thread3()
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();

            Tracer tracer = new Tracer(tm.GetType().ToString(), nameof(tm.TraceMethodInMethod));
            tracer.StartTrace();
            MInfo traceM = tm.TraceMethodInMethod();
            tracer.StopTrace();
            TraceResult tRes = tracer.GetTraceResult();

            Tracer sectracer = new Tracer(nameof(Program), nameof(MethodMain));
            sectracer.StartTrace();
            MethodMain();
            sectracer.StopTrace();
            TraceResult tRes2 = sectracer.GetTraceResult();

            clock.Stop();
            int tTime = (int)clock.ElapsedTicks;

            TInfo tInfo = new TInfo(Thread.CurrentThread.ManagedThreadId, tTime);
            MInfo mInfo = new MInfo(tRes);
            MInfo mInfo2 = new MInfo(tRes2);

            mInfo.NestedMethods = traceM.NestedMethods;

            tInfo.MethodInfAdd(mInfo);
            tInfo.MethodInfAdd(mInfo2);
            ThrInfList.Add(tInfo);

            //Console.WriteLine("3");
            //Thread.Sleep(1000);
        }

        public static void FileWrite(string fName, string sym)
        {
            using (FileStream fs = new FileStream(fName, FileMode.OpenOrCreate))
            {
                byte[] bytes = Encoding.Default.GetBytes(sym);
                fs.Write(bytes);
            }
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
