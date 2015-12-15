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
using Supporting;
using TheCompany;
using AllEmployees;

namespace Presentation
{
    /*!
     * NAME     : UIMenu<br>
     * PURPOSE  : The UIMenus class is used to display the various menus of the EMS1 project.
     *              These menus allow the user to select and call various methods in the Supporting and TheCompany class libraries.
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
            try
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine("\nMAIN MENU");
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
            catch(Exception ex)
            {
                Logger.Log("UIMemu", "MainMenu", ex.Message);
            }
        }

        /*!
         * FUNCTION     : private static void fileManagementMenu()
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to open, read, and write to the database file(s).
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : None
         * 
         */
        private static void fileManagementMenu()
        {
            try
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
                        /*!
                        * File Management Menu item 1 gets the data from the database file as returned from Database.LoadDatabase().
                        * It then parses the string and makes a temporary employee with those fields.
                        * If the temporary employee is valid, it adds it to the list of employees.
                        */
                        case '1':
                            {
                                Console.WriteLine("\nWhat file would you like to load the database from? (e.g. 'DBase.txt')");
                                string fileName = Console.ReadLine();
                                database = Database.LoadDatabase(fileName);
                                if (database[0] == "ERROR")
                                {
                                    Console.WriteLine("Failed to load the database.");
                                }
                                else
                                {
                                    foreach (string s in database)
                                    {
                                        int index = 0;
                                        string fname = "";
                                        string lname = "";
                                        string dob = "";
                                        string sin = "";
                                        string empType = "";
                                        while (s[index] != '|')
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
                                                    double sal = 0;
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
                                                        sal = Double.Parse(tmpSal);
                                                        index++;
                                                    }
                                                    index++;
                                                    FulltimeEmployee tmpFTEmp = new FulltimeEmployee(fname, lname, dob, sin, doh, dot, sal);
                                                    empList.Add(tmpFTEmp, tmpFTEmp.Validate());
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
                                                    empList.Add(tmpFTEmp, tmpFTEmp.Validate());
                                                    break;
                                                }
                                            case "CT":
                                                {
                                                    string cStartD = "";
                                                    string cStopD = "";
                                                    string tmpAmount = "";
                                                    double amount = 0;
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
                                                        amount = Double.Parse(tmpAmount);
                                                        index++;
                                                    }
                                                    index++;
                                                    ContractEmployee tmpFTEmp = new ContractEmployee(fname, lname, dob, sin, cStartD, cStopD, amount);
                                                    empList.Add(tmpFTEmp, tmpFTEmp.Validate());
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
                                                    empList.Add(tmpFTEmp, tmpFTEmp.Validate());
                                                    break;
                                                }
                                        }
                                    }
                                }
                                database.Clear();
                                break;
                            }
                        /*!
                        * File Management Menu item 2 creates a string with the employee data.
                        * It passes that string to Database.SaveDatabase() for saving.
                        */
                        case '2':
                            {
                                Console.WriteLine("\nWhat file would you like to load the database from? (e.g. 'DBase.txt')");
                                string fileName = Console.ReadLine();
                                string traStr = empList.GetDetailsToSave();
                                string tempStr = "";
                                for (int x = 0; x < traStr.Length; x++ )
                                {
                                    if(traStr[x] != '\n')
                                    {
                                        tempStr += traStr[x];
                                    }
                                    else
                                    {
                                        database.Add(tempStr);
                                        tempStr = "";
                                    }
                                }
                                Database.SaveDatabase(database, fileName);
                                database.Clear();
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
            catch (Exception ex)
            {
                Logger.Log("UIMemu", "fileManagementMenu", ex.Message);
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
            try
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
                        /*!
                         * Employee Management Menu item 1 prints gets each employees details and prints them to the screen.
                         */
                        case '1':
                            {
                                Console.WriteLine("\n" + empList.Traverse());
                                break;
                            }
                        /*!
                        * Employee Management Menu item 2 allows the user to create a new employee.
                        */
                        case '2':
                            {
                                string type = "";
                                bool correct = false;
                                while (!correct)
                                {
                                    Console.WriteLine("\nWhich type of employee would you like to add?");
                                    Console.WriteLine("1. Part Time Employee    2. Full Time Employee");
                                    Console.WriteLine("3. Seasonal Employee     4. Contract Employee");
                                    input = Console.ReadKey().KeyChar;
                                    switch (input)
                                    {
                                        case '1':
                                            {
                                                Console.WriteLine("\nEnter the Last Name of the new employee");
                                                type = "PT";
                                                correct = true;
                                                break;
                                            }
                                        case '2':
                                            {
                                                Console.WriteLine("\nEnter the Last Name of the new employee");
                                                type = "FT";
                                                correct = true;
                                                break;
                                            }
                                        case '3':
                                            {
                                                Console.WriteLine("\nEnter the Company Name");
                                                type = "CT";
                                                correct = true;
                                                break;
                                            }
                                        case '4':
                                            {
                                                Console.WriteLine("\nEnter the Last Name of the new employee");
                                                type = "SN";
                                                correct = true;
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }
                                }
                                string name = Console.ReadLine();
                                employeeDetailsMenu(name, type);
                                break;
                            }
                        /*!
                        * Employee Management Menu item 3 allows the user to modify existing employees.
                        */
                        case '3':
                            {
                                Console.WriteLine("\nWhat is the SIN of the Employee you would like to modify?");
                                string SIN = Console.ReadLine();
                                employeeDetailsMenu(SIN);
                                break;
                            }
                        /*!
                        * Employee Management Menu item 4 allows the user to remove existing employees.
                        */
                        case '4':
                            {
                                Console.WriteLine("\nWhat is the SIN of the Employee you would like to remove?");
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
            catch (Exception ex)
            {
                Logger.Log("UIMemu", "employeeManagementMenu", ex.Message);
            }
        }

        /*!
         * FUNCTION     : private static void employeeDetailsMenu(string employeeSIN)
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to update the details of a specified employee
         *                  in the employee database.
         * 
         * PARAMETERS   : \param string employeeSIN : The employee to display/update
         * 
         * RETURN       : None
         * 
         */
        private static void employeeDetailsMenu(string employeeSIN)
        {
            try
            {
                bool done = false;
                string temp = "";
                char input = ' ';
                Employee tempEmp = null;
                empList.Traverse(employeeSIN, ref tempEmp);
                if(tempEmp == null)
                {
                    Console.WriteLine("There is no employee in the database with that SIN.");
                    done = true;
                }
                while (!done)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS FOR {0}", tempEmp.firstName);
                    Console.WriteLine("1. Specify Base Employee Details");
                    switch (tempEmp.employeeType)
                    {
                        case "FT":
                            {
                                FulltimeEmployee tempFTEmp = (FulltimeEmployee)tempEmp;
                                Console.WriteLine("2. Specify Date of Hire");
                                Console.WriteLine("3. Specify Date of Termination");
                                Console.WriteLine("4. Specify Salary");
                                Console.WriteLine("9. Quit");
                                input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            bool innerDone = false;
                                            while (!innerDone)
                                            {
                                                Console.WriteLine("\n1. Specify First Name");
                                                Console.WriteLine("2. Specify Last Name");
                                                Console.WriteLine("3. Specify Date of Birth");
                                                Console.WriteLine("4. Specify Social Insurance Number");
                                                Console.WriteLine("9. Quit");
                                                input = Console.ReadKey().KeyChar;
                                                switch (input)
                                                {
                                                    case '1':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's First Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempFTEmp.SetFirstName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid First Name");
                                                            }
                                                            break;
                                                        }
                                                    case '2':
                                                        {
                                                            Console.WriteLine("What is the Employee's Last Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempFTEmp.SetLastName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Last Name");
                                                            }
                                                            break;
                                                        }
                                                    case '3':
                                                        {
                                                            Console.WriteLine("What is the Employee's Date of Birth? (YYYY-MM-DD)");
                                                            temp = Console.ReadLine();
                                                            if (!tempFTEmp.SetDateOfBirth(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Date of Birth");
                                                            }
                                                            break;
                                                        }
                                                    case '4':
                                                        {
                                                            Console.WriteLine("What is the new Employee's Social Insurance Number? (XXX XXX XXX)");
                                                            temp = Console.ReadLine();
                                                            if (!tempFTEmp.SetSIN(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Social Insurance Number");
                                                            }
                                                            break;
                                                        }
                                                    case '9':
                                                        {
                                                            innerDone = true;
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Date of Hire? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if(!tempFTEmp.SetDateOfHire(temp))
                                            {
                                                Console.WriteLine("Not a valid Date of Hire");
                                            }
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's Date of Termination? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if (!tempFTEmp.SetDateOfTermination(temp))
                                            {
                                                Console.WriteLine("Not a valid Date of Termination");
                                            }
                                            break;
                                        }
                                    case '4':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Salary? (Do not include the '$')");
                                            temp = Console.ReadLine();if(!tempFTEmp.SetSalary(temp))
                                            {
                                                Console.WriteLine("Not a valid Salary");
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
                                break;
                            }
                        case "PT":
                            {
                                ParttimeEmployee tempPTEmp = (ParttimeEmployee)tempEmp;
                                Console.WriteLine("2. Specify Date of Hire");
                                Console.WriteLine("3. Specify Date of Termination");
                                Console.WriteLine("4. Specify Hourly Rate");
                                Console.WriteLine("9. Quit");
                                input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            bool innerDone = false;
                                            while (!innerDone)
                                            {
                                                Console.WriteLine("\n1. Specify First Name");
                                                Console.WriteLine("2. Specify Last Name");
                                                Console.WriteLine("3. Specify Date of Birth");
                                                Console.WriteLine("4. Specify Social Insurance Number");
                                                Console.WriteLine("9. Quit");
                                                input = Console.ReadKey().KeyChar;
                                                switch (input)
                                                {
                                                    case '1':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's First Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempPTEmp.SetFirstName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid First Name");
                                                            }
                                                            break;
                                                        }
                                                    case '2':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Last Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempPTEmp.SetLastName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Last Name");
                                                            }
                                                            break;
                                                        }
                                                    case '3':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Date of Birth? (YYYY-MM-DD)");
                                                            temp = Console.ReadLine();
                                                            if (!tempPTEmp.SetDateOfBirth(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Date of Birth");
                                                            }
                                                            break;
                                                        }
                                                    case '4':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Social Insurance Number? (XXX XXX XXX)");
                                                            temp = Console.ReadLine();
                                                            if (!tempPTEmp.SetSIN(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Social Insurance Number");
                                                            }
                                                            break;
                                                        }
                                                    case '9':
                                                        {
                                                            innerDone = true;
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Date of Hire? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if (!tempPTEmp.SetDateOfHire(temp))
                                            {
                                                Console.WriteLine("Not a valid Date of Hire");
                                            }
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Date of Termination? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if (!tempPTEmp.SetDateOfTermination(temp))
                                            {
                                                Console.WriteLine("Not a valid Date of Termination");
                                            }
                                            break;
                                        }
                                    case '4':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Hourly Rate? (Do not include the '$')");
                                            temp = Console.ReadLine(); if (!tempPTEmp.SetHourlyRate(temp))
                                            {
                                                Console.WriteLine("Not a valid Hourly Rate");
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
                                break;
                            }
                        case "CT":
                            {
                                ContractEmployee tempCTEmp = (ContractEmployee)tempEmp;
                                Console.WriteLine("2. Specify Start Date");
                                Console.WriteLine("3. Specify End Date");
                                Console.WriteLine("4. Specify Fixed Contract Amount");
                                Console.WriteLine("9. Quit");
                                input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            bool innerDone = false;
                                            while (!innerDone)
                                            {
                                                Console.WriteLine("\n1. Specify Company Name");
                                                Console.WriteLine("2. Specify Date of Incorporation");
                                                Console.WriteLine("3. Specify Business Number");
                                                Console.WriteLine("9. Quit");
                                                input = Console.ReadKey().KeyChar;
                                                switch (input)
                                                {
                                                    case '1':
                                                        {
                                                            Console.WriteLine("\nWhat is the Company's Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempCTEmp.SetLastName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Company Name");
                                                            }
                                                            break;
                                                        }
                                                    case '3':
                                                        {
                                                            Console.WriteLine("\nWhat is the Company's Date of Incorporation? (YYYY-MM-DD)");
                                                            temp = Console.ReadLine();
                                                            if (!tempCTEmp.SetDateOfBirth(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Date of Incorporation");
                                                            }
                                                            break;
                                                        }
                                                    case '4':
                                                        {
                                                            Console.WriteLine("\nWhat is the Company's Business Number? (XXX XXX XXX)");
                                                            temp = Console.ReadLine();
                                                            if (!tempCTEmp.SetSIN(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Business Number");
                                                            }
                                                            break;
                                                        }
                                                    case '9':
                                                        {
                                                            innerDone = true;
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the Company's Contract Start Date? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if (!tempCTEmp.SetContractStartDate(temp))
                                            {
                                                Console.WriteLine("Not a valid Start Date");
                                            }
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the Company's Contract Stop Date? (YYYY-MM-DD)");
                                            temp = Console.ReadLine();
                                            if (!tempCTEmp.SetContractStopDate(temp))
                                            {
                                                Console.WriteLine("Not a valid Stop Date");
                                            }
                                            break;
                                        }
                                    case '4':
                                        {
                                            Console.WriteLine("\nWhat is the Company's Fixed Contract Amount? (Do not include the '$')");
                                            temp = Console.ReadLine(); if (!tempCTEmp.SetFixedContractAmount(temp))
                                            {
                                                Console.WriteLine("Not a valid Contract Amount");
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
                                break;
                            }
                        case "SN":
                            {
                                SeasonalEmployee tempSNEmp = (SeasonalEmployee)tempEmp;
                                Console.WriteLine("2. Specify Season");
                                Console.WriteLine("3. Specify Piece Pay");
                                Console.WriteLine("9. Quit");
                                input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            bool innerDone = false;
                                            while (!innerDone)
                                            {
                                                Console.WriteLine("\n1. Specify First Name");
                                                Console.WriteLine("2. Specify Last Name");
                                                Console.WriteLine("3. Specify Date of Birth");
                                                Console.WriteLine("4. Specify Social Insurance Number");
                                                Console.WriteLine("9. Quit");
                                                input = Console.ReadKey().KeyChar;
                                                switch (input)
                                                {
                                                    case '1':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's First Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempSNEmp.SetFirstName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid First Name");
                                                            }
                                                            break;
                                                        }
                                                    case '2':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Last Name?");
                                                            temp = Console.ReadLine();
                                                            if (!tempSNEmp.SetLastName(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Last Name");
                                                            }
                                                            break;
                                                        }
                                                    case '3':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Date of Birth? (YYYY-MM-DD)");
                                                            temp = Console.ReadLine();
                                                            if (!tempSNEmp.SetDateOfBirth(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Date of Birth");
                                                            }
                                                            break;
                                                        }
                                                    case '4':
                                                        {
                                                            Console.WriteLine("\nWhat is the Employee's Social Insurance Number? (XXX XXX XXX)");
                                                            temp = Console.ReadLine();
                                                            if (!tempSNEmp.SetSIN(temp))
                                                            {
                                                                Console.WriteLine("Not a valid Social Insurance Number");
                                                            }
                                                            break;
                                                        }
                                                    case '9':
                                                        {
                                                            innerDone = true;
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the Season the Employee's working in? (winter, spring, summer, fall)");
                                            temp = Console.ReadLine();
                                            if (!tempSNEmp.SetSeason(temp))
                                            {
                                                Console.WriteLine("Not a valid Season");
                                            }
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the Employee's Piece Pay? (Do not include the '$')");
                                            temp = Console.ReadLine(); if (!tempSNEmp.SetPiecePay(temp))
                                            {
                                                Console.WriteLine("Not a valid Piece Pay");
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
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("UIMemu", "employeeDetailsMenu(string)", ex.Message);
            }
        }

        /*!
         * FUNCTION     : private static void employeeDetailsMenu(string employee, string type)
         * 
         * DESCRIPTION  : This function displays the menu that allows the user to create new employees.
         * 
         * PARAMETERS   : \param string employee : The last/company name of the new employee
         *                \param string type     : The type of employee being created
         * 
         * RETURN       : None
         * 
         */
        private static void employeeDetailsMenu(string employee, string type)
        {
            try
            {
                bool done = false;
                string fname = "";
                string lname = employee;
                string dob = "";
                string sin = "";
                string doh = "";
                string dot = "";
                string tmpSal = "";
                double sal = 0;
                string tmpRate = "";
                double rate = 0;
                string cStartD = "";
                string cStopD = "";
                string tmpAmount = "";
                double amount = 0;
                string season = "";
                string tmpPay = "";
                double pay = 0;
                while (!done)
                {
                    Console.WriteLine("\nEMPLOYEE DETAILS FOR {0}", lname);
                    Console.WriteLine("1. Specify Base Employee Details");
                    switch(type)
                    {
                        case "FT":
                            {
                                Console.WriteLine("2. Specify Date of Hire");
                                Console.WriteLine("3. Specify Date of Termination");
                                Console.WriteLine("4. Specify Salary");
                                Console.WriteLine("9. Quit");
                                char input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's First Name?");
                                            fname = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Date of Birth? (YYYY-MM-DD)");
                                            dob = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Social Insurance Number? (XXX XXX XXX)");
                                            sin = Console.ReadLine();
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's Date of Hire? (YYYY-MM-DD)");
                                            doh = Console.ReadLine();
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's Date of Termination? (YYYY-MM-DD)");
                                            dot = Console.ReadLine();
                                            break;
                                        }
                                    case '4':
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("\nWhat is the new Employee's Salary? (Do not include the '$')");
                                                tmpSal = Console.ReadLine();
                                                try
                                                {
                                                    sal = Double.Parse(tmpSal);
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Not a number");
                                                }
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
                                break;
                            }
                        case "PT":
                            {
                                Console.WriteLine("2. Specify Date of Hire");
                                Console.WriteLine("3. Specify Date of Termination");
                                Console.WriteLine("4. Specify Hourly Rate");
                                Console.WriteLine("9. Quit");
                                char input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's First Name?");
                                            fname = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Date of Birth? (YYYY-MM-DD)");
                                            dob = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Social Insurance Number? (XXX XXX XXX)");
                                            sin = Console.ReadLine();
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's Date of Hire? (YYYY-MM-DD)");
                                            doh = Console.ReadLine();
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's Date of Termination? (YYYY-MM-DD)");
                                            dot = Console.ReadLine();
                                            break;
                                        }
                                    case '4':
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("\nWhat is the new Employee's Hourly Rate? (Do not include the '$')");
                                                tmpRate = Console.ReadLine();
                                                try
                                                {
                                                    rate = Double.Parse(tmpRate);
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Not a number");
                                                }
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
                                break;
                            }
                        case "CT":
                            {
                                Console.WriteLine("2. Specify Contract Start Date");
                                Console.WriteLine("3. Specify Contract End Date");
                                Console.WriteLine("4. Specify Fixed Contract Amount");
                                Console.WriteLine("9. Quit");
                                char input = Console.ReadKey().KeyChar;
                                switch(input)
                                {
                                    case '1':
                                        {
                                            Console.WriteLine("What is the new Company's Date of Incorporation? (YYYY-MM-DD)");
                                            dob = Console.ReadLine();
                                            Console.WriteLine("What is the new Company's Business Number? (XXXXX XXXX)");
                                            sin = Console.ReadLine();
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("What is the Contract's Start Date? (YYYY-MM-DD)");
                                            cStartD = Console.ReadLine();
                                            break;
                                        }
                                    case '3':
                                        {
                                            Console.WriteLine("What is the Contract's End Date? (YYYY-MM-DD)");
                                            cStopD = Console.ReadLine();
                                            break;
                                        }
                                    case '4':
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("What is the Contract's Fixed Amount? (Do not include the '$')");
                                                tmpAmount = Console.ReadLine();
                                                try
                                                {
                                                    amount = Double.Parse(tmpAmount);
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Not a number");
                                                }
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
                                break;
                            }
                        case "SN":
                            {
                                Console.WriteLine("2. Specify Season");
                                Console.WriteLine("3. Specify Piece Pay");
                                Console.WriteLine("9. Quit");
                                char input = Console.ReadKey().KeyChar;
                                switch (input)
                                {
                                    case '1':
                                        {
                                            Console.WriteLine("\nWhat is the new Employee's First Name?");
                                            fname = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Date of Birth? (YYYY-MM-DD)");
                                            dob = Console.ReadLine();
                                            Console.WriteLine("What is the new Employee's Social Insurance Number? (XXX XXX XXX)");
                                            sin = Console.ReadLine();
                                            break;
                                        }
                                    case '2':
                                        {
                                            Console.WriteLine("\nWhat is the Season the new Employee's working in? (winter, spring, summer, fall)");
                                            season = Console.ReadLine();
                                            break;
                                        }
                                    case '3':
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("\nWhat is the new Employee's Piece Pay? (Do not include the '$')");
                                                tmpPay = Console.ReadLine();
                                                try
                                                {
                                                    pay = Double.Parse(tmpPay);
                                                    break;
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Not a number");
                                                }
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
                                break;
                            }
                    }
                }
            /* Creating employees
             */
            switch(type)
            {
                case "FT":
                    {
                        FulltimeEmployee tmpFTEmp = new FulltimeEmployee(fname, lname, dob, sin, doh, dot, sal);
                        empList.Add(tmpFTEmp, tmpFTEmp.Validate());
                        break;
                    }
                case "PT":
                    {
                        ParttimeEmployee tmpPTEmp = new ParttimeEmployee(fname, lname, dob, sin, doh, dot, rate);
                        empList.Add(tmpPTEmp, tmpPTEmp.Validate());
                        break;
                    }
                case "CT":
                    {
                        ContractEmployee tmpCTEmp = new ContractEmployee(fname, lname, dob, sin, cStartD, cStopD, amount);
                        empList.Add(tmpCTEmp, tmpCTEmp.Validate());
                        break;
                    }
                case "SN":
                    {
                        SeasonalEmployee tmpSNEmp = new SeasonalEmployee(fname, lname, dob, sin, season, pay);
                        empList.Add(tmpSNEmp, tmpSNEmp.Validate());
                        break;
                    }
            }
            }
            catch (Exception ex)
            {
                Logger.Log("UIMemu", "employeeDetailsMenu(string, string)", ex.Message);
            }
        }
    }
}
