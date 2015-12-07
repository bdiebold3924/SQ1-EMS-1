using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
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

        public static String parseDate()
        {
            DateTime localDate = DateTime.Now;
            String year="",month= "",day="";
            String retVal = localDate.ToString();
            Console.WriteLine(localDate.ToString());
            int i = 0;
            int stage = 0;
            while(true)
            {
                if(stage == 0)
                {
                    year += retVal[i];
                    i++;
                }
                else if(stage == 1)
                {
                    month += retVal[i];
                    i++;
                }
                else if (stage == 2)
                {
                    day += retVal[i];
                    i++;
                }
                if(retVal[i] == '-')
                {
                    stage++;
                    i++;
                }
                if(retVal[i] == ' ')
                {
                    break;
                }
            }
            retVal = year + "-" + month + "-" + day;
            return retVal;
        }

        public static int dateToInt(String date)
        {//NOT USED
            String removeDash = date.Replace("-","");
            int retVal = Int32.Parse(removeDash);
            return retVal;
        }

        public static void WriteToFile(String message)
        {
            String dir = "Logs\\ems." + parseDate() + ".log";
            using (StreamWriter append = new StreamWriter(File.Open(dir, System.IO.FileMode.Append)))
            {
                append.WriteLine(message);
                append.Close();
            }
        }

    }
}
