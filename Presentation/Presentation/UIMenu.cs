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

namespace Presentation
{
    /*!
     * NAME     : UIMenu<br>
     * PURPOSE  : The UIMenus class is used to display the various menus of the EMS1 project.
     *              These menus allow the user to select and call various methods in the Support and TheCompany class libraries.
     */
    public class UIMenu
    {
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
                            //! TODO: Insert call to open/read from file method of logging class
                            break;
                        }
                    case '2':
                        {
                            //! TODO: Insert call to save method of logging class
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
                            //! TODO: Insert call to display method of company class library
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("Enter the name of the new employee");
                            string name = Console.ReadLine();
                            employeeDetailsMenu(name);
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Which employee would you like to modify?");
                            string name = Console.ReadLine();
                            employeeDetailsMenu(name);
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("Which Employee would you like to remove?");
                            string name = Console.ReadLine();
                            //! TODO: Traverse the company class/call method to traverse the company class
                            Console.WriteLine("Are you sure you want to delete {0}? y/n", name);
                            input = Console.ReadKey().KeyChar;
                            switch (input)
                            {
                                case 'y':
                                    {
                                        //! TODO: Insert call to delete method of company class library
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
                //! TODO: Add options for each employee type specific variable
                // Console.WriteLine("2. Manage Employees");
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
            }
        }
    }
}
