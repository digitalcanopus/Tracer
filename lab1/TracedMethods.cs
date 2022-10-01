using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab1
{
    public static class TracedMethods
    {
        public static void FirstMethod()
        {
            Thread.Sleep(1000); 
        }

        public static void SecondMethod()
        {
            Thread.Sleep(2000);
        }

        public static void ThirdMethod()
        {
            //add tracing 
            FirstMethod();
            SecondMethod();
        }
    }
}
