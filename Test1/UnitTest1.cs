using lab1;
using Library1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompareSleep1ToSleep2()
        {
            Tracer tr1 = new Tracer(nameof(Tracer), nameof(TracedMethods.MSleep1));
            tr1.StartTrace();
            TracedMethods.MSleep1();
            tr1.StopTrace();

            Tracer tr2 = new Tracer(nameof(Tracer), nameof(TracedMethods.MSleep2));
            tr2.StartTrace();
            TracedMethods.MSleep2();
            tr2.StopTrace();

            TraceResult res1 = tr1.GetTraceResult();
            TraceResult res2 = tr2.GetTraceResult();

            Assert.IsTrue(res1.Time < res2.Time);
        }

        [TestMethod]
        public void CompareArithm1ToArithm2()
        {
            Tracer tr1 = new Tracer(nameof(Tracer), nameof(TracedMethods.SumArithmProgr1));
            tr1.StartTrace();
            TracedMethods.SumArithmProgr1();
            tr1.StopTrace();

            Tracer tr2 = new Tracer(nameof(Tracer), nameof(TracedMethods.SumArithmProgr2));
            tr2.StartTrace();
            TracedMethods.SumArithmProgr2();
            tr2.StopTrace();

            TraceResult res1 = tr1.GetTraceResult();
            TraceResult res2 = tr2.GetTraceResult();

            Assert.IsTrue(res1.Time > res2.Time);
        }

        [TestMethod]
        public void CompareSimpleToNested()
        {
            Tracer tr1 = new Tracer(nameof(Tracer), nameof(TracedMethods.TraceMethod1));
            tr1.StartTrace();
            TracedMethods.TraceMethod1();
            tr1.StopTrace();

            TracedMethods trace = new TracedMethods();
            Tracer tr2 = new Tracer(nameof(Tracer), nameof(TracedMethods.TraceMethodInMethod));
            tr2.StartTrace();
            trace.TraceMethodInMethod();
            tr2.StopTrace();

            TraceResult res1 = tr1.GetTraceResult();
            TraceResult res2 = tr2.GetTraceResult();

            Assert.IsTrue(res1.Time < res2.Time);
        }

        [TestMethod]
        public void CompareClassNames()
        {
            Tracer tracer = new Tracer(nameof(Program), nameof(Program.MethodMain));
            tracer.StartTrace();
            Program.MethodMain();
            tracer.StopTrace();

            TraceResult result = tracer.GetTraceResult();

            Assert.AreEqual("Program", result.ClassName);
        }

        [TestMethod]
        public void CompareMethodsNames()
        {
            Tracer tracer = new Tracer(nameof(TracedMethods), nameof(TracedMethods.TraceMethod2));
            tracer.StartTrace();
            TracedMethods.TraceMethod2();
            tracer.StopTrace();

            TraceResult result = tracer.GetTraceResult();

            Assert.AreEqual("TraceMethod2", result.MethodName);
        }
    }
}
