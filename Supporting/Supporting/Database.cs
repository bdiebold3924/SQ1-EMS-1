using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportClass
{
    public class Database
    {
        /**
* \brief Opens database and loads it into an array of strings
* \details <b>Details</b>
*
* \param N/A
*
*/
        public static List<string> LoadDatabase(string fileName)
        {
            string temp = "";
            int index = 0;
            List<string> data = new List<string>();
            string database = "";
            string dir = "//DBase//" + fileName;
            try
            {
                database = System.IO.File.ReadAllText(dir);
            }
            catch(Exception ex)
            {
                Logger.Log("Database","LoadDatabase",ex.Message);
                data.Add("ERROR");
                return data; 
            }
            for (int i = 0; index < database.Length; i++)
            {
                /*        For example, here is a typical FulltimeEmployee type of record:
;                       FT|Clarke|Sean|333333333|1950-05-05|1960-05-05|N/A|15000.00|
;
;                Here is a typical ParttimeEmployee type of record:
;                       PT|Clarke|Sean|333333333|1950-05-05|1955-05-05|1959-05-05|1.23|
;
;                Here is a typical ContractEmployee type of record:
;                       CT|Sean Inc.||170123888|1970-01-01|1980-01-01|1985-12-31|1000000.00|
;
;                Here is a typical SeasonalEmployee type of record:
;                       SN|Clarke|Sean|333333333|1950-05-05|WINTER|0.15|*/
                string employeeInfo = "";
                string type = "";
                while (database[index] != '|')
                {
                    type += database[index];
                    //removes the unneeded characters
                    if (type.Contains('\r') || type.Contains('\n'))
                    {
                        type = "";
                    }
                    index++;
                }
                employeeInfo += type;
                employeeInfo += "|";
                index++;
                //get basic employee information
                for (int x = 0; x < 4; x++)
                {
                    while (database[index] != '|')
                    {
                        temp += database[index];
                        index++;
                    }
                    temp += "|";
                    employeeInfo += temp;
                    temp = "";
                    index++;

                }
                //index++;
                if(type == "FT")
                {
                    for (int x = 0; x < 3; x++)
                    {
                        while (database[index] != '|')
                        {
                            temp += database[index];
                            index++;
                        }
                        temp += "|";
                        employeeInfo += temp;
                        temp = "";
                        index++;
                    }
                }
                if(type == "PT")
                {
                    for (int x = 0; x < 3; x++)
                    {
                        while (database[index] != '|')
                        {
                            temp += database[index];
                            index++;
                        }
                        temp += "|";
                        employeeInfo += temp;
                        temp = "";
                        index++;
                    }
                }
                if(type == "CT")
                {
                    for (int x = 0; x < 3; x++)
                    {
                        while (database[index] != '|')
                        {
                            temp += database[index];
                            index++;
                        }
                        temp += "|";
                        employeeInfo += temp;
                        temp = "";
                        index++;
                    }
                }
                if(type == "SN")
                {
                    for (int x = 0; x < 2; x++)
                    {
                        while (database[index] != '|')
                        {
                            temp += database[index];
                            index++;
                        }
                        temp += "|";
                        employeeInfo += temp;
                        temp = "";
                        index++;
                    }
                }
                data.Add(employeeInfo);
                employeeInfo = "";

            }
            return data;
        }

        /**
* \brief Saves the database to a file
* \details <b>Details</b>
*
* \param List<string> database : all the employee information
*
*/
        public static Boolean SaveDatabase(List<string> database)
        {
            
            try
            {
                StreamWriter file = new StreamWriter("database.txt");
                for(int i = 0; i < database.Count-1; i++)
                {
                    file.WriteLine(database[i]);
                }
                file.Close();
            }
            catch (Exception ex)
            {//save failed
                return false;
            }
            return true;
        }

        /**
* \brief Deletes the database
* \details <b>Details</b>
*
* \param N/A
*
*/
        public static Boolean DeleteDatabase()
        {
            try
            {
                File.Delete("database.txt");
            }
            catch (Exception ex)
            {//delete failed
                return false;
            }
            return true;
        }

        /**
* \brief Saves the database a loads it again
* \details <b>Details</b>
*
* \param N/A
*
*/
        public static List<string> ReloadDatabase(List<string> database)
        {
            SaveDatabase(database);
            return LoadDatabase("database.txt");
        }

    }
}
