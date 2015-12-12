/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the UIMenu Class<br>
 * PROJECT  :   SQ1 - EMS1<br>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportClass;
using TheCompany;
using AllEmployees;

namespace Presentation
{
    /*!
     * NAME     : UIMenu<br>
     * PURPOSE  : The UIMenus class is used to display the various menus of the EMS1 project.
     *              These menus allow the user to select and call various methods in the Support and TheCompany class libraries.
     */
    public static class UIMenu
    {

        static Company empList = new Company();
        /*!
         * FUNCTION     : public static void MainMenu()
         * 
         * DESCRIPTION  : This function displays the main menu for the user interface.
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : None
         * 
         */
        public static void MainMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. Manage EMS DBase Files");
                Console.WriteLine("2. Manage Employees");
                Console.WriteLine("9. Quit");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            fileManagementMenu();
                            break;
                        }
                    case '2':
                        {
                            employeeManagementMenu();
                            break;
                        }
                    case '9':
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        /*!
         * FUNCTION     : private static void fileManagementMenu()
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to open, read, and write to the log file(s).
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : None
         * 
         */
        private static void fileManagementMenu()
        {
            bool done = false;
            List<string> database = new List<string>();
            while (!done)
            {
                Console.WriteLine("\nFILE MANAGEMENT MENU");
                Console.WriteLine("1. Load EMS DBase from file");
                Console.WriteLine("2. Save Employee Set to EMS DBase File");
                Console.WriteLine("9. Return to Main Menu");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            string fname = "";
                            string lname = "";
                            string dob = "";
                            string sin = "";
                            string empType = "";
                            database = Database.LoadDatabase();
                            if(database[0] == "ERROR")
                            {
                                Console.WriteLine("Failed to load the database.");
                            }
                            foreach(string s in database)
                            {
                                int index = 0;
                                while(s[index] != '|')
                                {
                                    empType += s[index];
                                    index++;
                                }
                                index++;
                                while (s[index] != '|')
                                {
                                    lname += s[index];
                                    index++;
                                }
                                index++;
                                while (s[index] != '|')
                                {
                                    fname += s[index];
                                    index++;
                                }
                                index++;
                                while (s[index] != '|')
                                {
                                    sin += s[index];
                                    index++;
                                }
                                index++;
                                while (s[index] != '|')
                                {
                                    dob += s[index];
                                    index++;
                                }
                                index++;
                                switch (empType)
                                {
                                    case "FT":
                                        {
                                            string doh = "";
                                            string dot = "";
                                            string tmpSal = "";
                                            int sal = 0;
                                            while (s[index] != '|')
                                            {
                                                doh += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                dot += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                tmpSal += s[index];
                                                sal = Int32.Parse(tmpSal);
                                                index++;
                                            }
                                            index++;
                                            FulltimeEmployee tmpFTEmp = new FulltimeEmployee(fname, lname, dob, sin, doh, dot, sal);
                                            if(tmpFTEmp.Validate())
                                            {
                                                empList.Add(tmpFTEmp, true);
                                            }
                                            break;
                                        }
                                    case "PT":
                                        {
                                            string doh = "";
                                            string dot = "";
                                            string tmpRate = "";
                                            double rate = 0;
                                            while (s[index] != '|')
                                            {
                                                doh += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                dot += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                tmpRate += s[index];
                                                rate = Double.Parse(tmpRate);
                                                index++;
                                            }
                                            index++;
                                            ParttimeEmployee tmpFTEmp = new ParttimeEmployee(fname, lname, dob, sin, doh, dot, rate);
                                            if (tmpFTEmp.Validate())
                                            {
                                                empList.Add(tmpFTEmp, true);
                                            }
                                            break;
                                        }
                                    case "CT":
                                        {
                                            string cStartD = "";
                                            string cStopD = "";
                                            string tmpAmount = "";
                                            int amount = 0;
                                            while (s[index] != '|')
                                            {
                                                cStartD += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                cStopD += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                tmpAmount += s[index];
                                                amount = Int32.Parse(tmpAmount);
                                                index++;
                                            }
                                            index++;
                                            ContractEmployee tmpFTEmp = new ContractEmployee(fname, lname, dob, sin, cStartD, cStopD, amount);
                                            if (tmpFTEmp.Validate())
                                            {
                                                empList.Add(tmpFTEmp, true);
                                            }
                                            break;
                                        }
                                    case "SN":
                                        {
                                            string season = "";
                                            string tmpPay = "";
                                            double pay = 0;
                                            while (s[index] != '|')
                                            {
                                                season += s[index];
                                                index++;
                                            }
                                            index++;
                                            while (s[index] != '|')
                                            {
                                                tmpPay += s[index];
                                                pay = Double.Parse(tmpPay);
                                                index++;
                                            }
                                            index++;
                                            SeasonalEmployee tmpFTEmp = new SeasonalEmployee(fname, lname, dob, sin, season, pay);
                                            if (tmpFTEmp.Validate())
                                            {
                                                empList.Add(tmpFTEmp, true);
                                            }
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case '2':
                        {
                            Database.SaveDatabase(database);
                            break;
                        }
                    case '9':
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        /*!
         * FUNCTION     : private static void employeeManagementMenu()
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to read and write to the employee database.
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : None
         * 
         */
        private static void employeeManagementMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\nEMPLOYEE MANAGEMENT");
                Console.WriteLine("1. Display Employee Set");
                Console.WriteLine("2. Create a NEW Employee");
                Console.WriteLine("3. Modify an EXISTING Employee");
                Console.WriteLine("4. Remove an EXISTING Employee");
                Console.WriteLine("9. Quit");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            empList.Traverse();
                            break;
                        }
                    case '2':
                        {
                            string type = "";
                            Console.WriteLine("Which type of employee would you like to add?");
                            Console.WriteLine("1. Part Time Employee    2. Full Time Employee");
                            Console.WriteLine("3. Seasonal Employee     4. Contract Employee");
                            input = Console.ReadKey().KeyChar;
                            switch(input)
                            {
                                case '1':
                                    {
                                        type = "PT";
                                        break;
                                    }
                                case '2':
                                    {
                                        type = "FT";
                                        break;
                                    }
                                case '3':
                                    {
                                        type = "CT";
                                        break;
                                    }
                                case '4':
                                    {
                                        type = "SN";
                                        break;
                                    }
                            }
                            Console.WriteLine("Enter the name of the new employee");
                            string name = Console.ReadLine();
                            employeeDetailsMenu(name, type);
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("What is the SIN of the Employee you would like to modify?");
                            string SIN = Console.ReadLine();
                            employeeDetailsMenu(SIN);
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("What is the SIN of the Employee you would like to remove?");
                            string SIN = Console.ReadLine();
                            string empData = empList.Traverse(SIN);
                            if (empData != "")
                            {
                                Console.WriteLine(empData);
                                Console.WriteLine("Are you sure you want to delete this employee? y/n");
                                input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case 'y':
                                        {
                                            empList.Remove(SIN);
                                            break;
                                        }
                                    case 'n':
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no employee in the database with that SIN.");
                            }
                            break;
                        }
                    case '9':
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        /*!
         * FUNCTION     : private static void employeeDetailsMenu(string employee)
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to view/update the details of a specified employee
         *                  in the employee database.
         * 
         * PARAMETERS   : \param string employee : THe employee to display/update
         * 
         * RETURN       : None
         * 
         */
        private static void employeeDetailsMenu(string employee)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\nEMPLOYEE DETAILS FOR {0}", employee);
                Console.WriteLine("1. Specify Base Employee Details");
                Console.WriteLine("2. Specify the Date of Hire");
                Console.WriteLine("3. Specify the Date of Termination");
                Console.WriteLine("4. Specify the Employee's Hourly Rate");
                Console.WriteLine("9. Quit");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            Console.WriteLine("Which Value Would You Like to Modify?");
                            Console.WriteLine("1. Employee Type     2. First Name");
                            Console.WriteLine("3. Last Name         4. Date of Birth");
                            Console.WriteLine("5. Social Insurance Number");
                            input = Console.ReadKey().KeyChar;
                            switch(input)
                            {
                                case '1':
                                    {
                                        Console.WriteLine("What is the new Employee Type? (CC)");
                                        break;
                                    }
                                case '2':
                                    {
                                        Console.WriteLine("What is the new First Name?");
                                        break;
                                    }
                                case '3':
                                    {
                                        Console.WriteLine("What is the new Last Name?");
                                        break;
                                    }
                                case '4':
                                    {
                                        Console.WriteLine("What is the new Date of Birth? (YYYY-MM-DD)");
                                        break;
                                    }
                                case '5':
                                    {
                                        Console.WriteLine("What is the new Social Insurance Number? (XXX XXX XXX)");
                                        break;
                                    }
                            }
                            break;
                        }
                    case '2':
                        {
                            //! TODO: Get employee details from user and pass them to the company class' validation method
                            break;
                        }
                    case '9':
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        /*!
         * FUNCTION     : private static void employeeDetailsMenu(string employee)
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to view/update the details of a specified employee
         *                  in the employee database.
         * 
         * PARAMETERS   : \param string employee : THe employee to display/update
         * 
         * RETURN       : None
         * 
         */
        private static void employeeDetailsMenu(string employee, string type)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\nEMPLOYEE DETAILS FOR {0}", employee);
                Console.WriteLine("1. Specify Base Employee Details");
                Console.WriteLine("9. Quit");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            //! TODO: Get employee details from user and pass them to the company class' validation method
                            break;
                        }
                    case '2':
                        {
                            //! TODO: Get employee details from user and pass them to the company class' validation method
                            break;
                        }
                    case '9':
                        {
                            done = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                break;
            }
        }
    }
}
