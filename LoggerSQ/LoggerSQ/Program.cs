using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace LoggerSQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //using System.Reflection
            Console.WriteLine(Logger.TestLog(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "Meh"));
        }
    }
}
