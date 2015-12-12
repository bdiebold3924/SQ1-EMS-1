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
            String date = Logger.parseDate();
            int dateInt = Logger.dateToInt(date);
            Console.WriteLine(dateInt.ToString());
            //using System.Reflection
            Console.WriteLine(Logger.TestLog(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "Meh"));
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "even more in the future! ");
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "2nd Log");
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "3rd");
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "MORE logging");
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "asfsdfasdfdsf");
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "Employee 2 fired");

        }
    }
}
