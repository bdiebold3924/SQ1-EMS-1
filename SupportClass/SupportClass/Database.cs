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
        public static List<string> LoadDatabase()
        {
            string temp = "";
            int index = 0;
            List<string> data = new List<string>();
            string database = "";
            try
            {
                 database = System.IO.File.ReadAllText(@"database.txt");
            }
            catch(Exception ex)
            {
                data.Add("ERROR");
                return data; 
            }
            for (int i = 0; i < database.Length; i++)
            {
                int stage = 0;
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
                //get basic employee information
                for (int x = 0; x < 4; x++)
                {
                    while (database[index] != '|')
                    {
                        temp += database[index];
                        index++;
                    }
                    temp += "|";
                    employeeInfo = temp;
                    temp = "";

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
            return LoadDatabase();
        }

    }
}
