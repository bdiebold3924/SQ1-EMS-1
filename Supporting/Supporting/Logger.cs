/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the Logger Class<br>
 * PROJECT  :   SQ1 - EMS1<br>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Supporting
{
    public class Logger
    {
        /**
* \brief Recieves the message to be logged and writes it to a file
* \details <b>Details</b>
*
* \param String ClassName - Name of the class that the message came from
* \param String MethodName - Name of the method that the message came from
* \param String message - The message to be logged
*
*/
        public static void Log(String ClassName, String MethodName, String message)
        {
            DateTime Date = DateTime.Now;
            String logMessage = "[" + Date.ToString() + "] " + "[" + ClassName + "." + MethodName + "]" + " - " + message;
            WriteToFile(logMessage);
        }

        /**
* \brief Test Method - Recieves the message to be logged and writes to the screen
* \details <b>Details</b>
*
* \param String ClassName - Name of the class that the message came from
* \param String MethodName - Name of the method that the message came from
* \param String message - The message to be logged
*
*/
        public static String TestLog(String ClassName, String MethodName, String message)
        {
            DateTime Date = DateTime.Now;
            String logMessage = "[" + Date.ToString() + "] " + "[" + ClassName + "." + MethodName + "]" + " - " + message;
            return logMessage;
        }

        /**
* \brief Parse the current date into a useable format
* \details <b>Details</b>
*
* \param N/A
*
*/
        public static String parseDate()
        {
            DateTime localDate = DateTime.Now;
            String year = "", month = "", day = "";
            String retVal = localDate.ToString();
            int i = 0;
            int stage = 0;
            while (true)
            {
                if (stage == 0)
                {
                    year += retVal[i];
                    i++;
                }
                else if (stage == 1)
                {
                    month += retVal[i];
                    i++;
                }
                else if (stage == 2)
                {
                    day += retVal[i];
                    i++;
                }
                if (retVal[i] == '-')
                {
                    stage++;
                    i++;
                }
                if (retVal[i] == ' ')
                {
                    break;
                }
            }
            retVal = year + "-" + month + "-" + day;
            return retVal;
        }

        /**
* \brief Recieves the message and writes it to the correct file
* \details <b>Details</b>
*
* \param String message - The message to write to a file
*
*/
        public static void WriteToFile(String message)
        {
            DirectoryInfo di = Directory.CreateDirectory("Logs\\");
            String dir = "Logs\\ems." + parseDate() + ".log";
            using (StreamWriter append = new StreamWriter(File.Open(dir, System.IO.FileMode.Append)))
            {
                append.WriteLine(message);
                append.Close();
            }
        }

        private static Boolean NewSaveFile()
        {
            return true;
        }

    }
}
