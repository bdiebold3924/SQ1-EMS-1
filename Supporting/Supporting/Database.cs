/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the Database Class<br>
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
            List<string> data = new List<string>();
            try
            {
                string temp = "";
                int index = 0;
                string database = "";
                string dir = "DBase//" + fileName;
                try
                {
                    database = System.IO.File.ReadAllText(dir);
                }
                catch (Exception ex)
                {
                    Logger.Log("Database", "LoadDatabase", ex.Message);
                    data.Add("ERROR");
                    return data;
                }
                for (int i = 0; index < (database.Length - 2); i++)
                {
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
                    if (type == "FT")
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
                    if (type == "PT")
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
                    if (type == "CT")
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
                    if (type == "SN")
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
                    string message = "Total number of records read: " + data.Count().ToString();
                    Logger.Log("Database", "LoadDatabase", message);
                }
            }
            catch(Exception ex)
            {
                Logger.Log("Database", "LoadDatabase", ex.Message);
                data.Add("ERROR");
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
        public static Boolean SaveDatabase(List<string> database, string fileName)
        {
            try
            {
                StreamWriter file = new StreamWriter("DBase//" + fileName);
                for(int i = 0; i < database.Count; i++)
                {
                    file.WriteLine(database[i]);
                }
                string message = "Total number of records: " + database.Count().ToString() + ", Total number of valid records: " + database.Count().ToString();
                Logger.Log("Database", "SaveDatabase", message);
                file.Close();
            }
            catch (Exception ex)
            {//save failed
                Logger.Log("Database", "SaveDatabase", ex.Message);
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
                Logger.Log("Database", "DeleteDatabase", ex.Message);
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
            SaveDatabase(database, "database.txt");
            return LoadDatabase("database.txt");
        }

    }
}
