using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPresentationClass
{
    public class UIMenu
    {
        public static void DisplayMainMenu()
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
                            displayFMMenu();
                            break;
                        }
                    case '2':
                        {
                            displayEMMenu();
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

        private static void displayFMMenu()
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
                            //TODO: Call open/read from file method of logging class
                            break;
                        }
                    case '2':
                        {
                            //TODO: Call save method of logging class
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

        private static void displayEMMenu()
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
                            //TODO: Call display method of company class library
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("Enter the name of the new employee");
                            string name = Console.ReadLine();
                            displayEDMenu(name);
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Which employee would you like to modify?");
                            string name = Console.ReadLine();
                            displayEDMenu(name);
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("Which Employee would you like to remove?");
                            string name = Console.ReadLine();
                            //TODO: Traverse the company class/call method to traverse the company class
                            Console.WriteLine("Are you sure you want to delete {0}? y/n", name);
                            input = Console.ReadKey().KeyChar;
                            switch(input)
                            {
                                case 'y':
                                    {
                                        //TODO: Call delete method of company class library
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

        private static void displayEDMenu(string employee)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\nEMPLOYEE DETAILS FOR {0}", employee);
                Console.WriteLine("1. Specify Base Employee Details");
                /* TODO: Add options for each employee type specific variable
                 * Console.WriteLine("2. Manage Employees");*/
                Console.WriteLine("9. Quit");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            //TODO: Get employee details from user and pass them to the company class' validation method
                            break;
                        }
                    case '2':
                        {
                            //TODO: Get employee details from user and pass them to the company class' validation method
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
