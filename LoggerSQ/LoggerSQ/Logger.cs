using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerSQ
{
    /*
     Use
     *      using System.Reflection
     *                   ClassName                                           MethodName                       Event
            Logger.Log(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "Event");
     */
    public abstract class Logger
    {

        public static void Log(String ClassName, String MethodName, String message)
        {
            DateTime Date = DateTime.Now;
            String logMessage = "[" + Date.ToString() + "] " + "[" + ClassName + "." + MethodName + "]" + " - " + message; 
            WriteToFile(logMessage);
        }

        public static String TestLog(String ClassName, String MethodName, String message)
        {
            DateTime Date = DateTime.Now;
            String logMessage = "[" + Date.ToString() + "] " + "["+ClassName+ "." +MethodName+"]"+" - " + message;  
            return logMessage;
        }

        public static void WriteToFile(String message)
        {
              //TO-DO
        }

    }
}
