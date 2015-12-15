using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Supporting;
/// \class library called AllEmployees
/// \brief purpose of this library is to contain the 5 employee type classes needed for EMS-1



namespace AllEmployees
{
    /** Class: Employee
    
        Purpose: The following class is a parent class to 4 other sub-classes of types of employees. This class holds 
                an employees first and last name, date of birth, and their SIN number and is the main object to be 
                worked with when creating new employees.    
                */
    public class Employee
    {
        /* ATTRIBUTES */

        public string firstName; ///< first name of the employee, stored as a string
        public string lastName;  ///< last name of the employee stored as a string
        public string dateOfBirth; ///< date of birth will be stored as a string
        public string socialInsuranceNumber;  ///< 9 digit number that will be stored as a string

        public string employeeType;  ///< To be used to keep track of which employee type we are currently working with



        /** Name: Employee()
        Params: None
        Use: The following is a default constructor that sets all attribute values to zero values.
        */
        public Employee()    //default constructor
        {
            firstName = null;
            lastName = null;
            dateOfBirth = null;
            socialInsuranceNumber = null;

        }
        /** Name: Employee()
        Params: string _firstName, string _lastName
        Use: The following is a constructor that takes an employees first and last name and sets the classes attributes
            to them. As well, it sets the remaining attributes to zero values.
            */
        
        public Employee(string _firstName, string _lastName)    //constructor that takes names 
        {
            firstName = String.Copy(_firstName);
            lastName = String.Copy(_lastName);

            dateOfBirth = null;
            socialInsuranceNumber = null;
        }

        /** Name: Employee()
        Params: string newFirstName, string newLastName, string newDateOfBirth, string newSIN
        Use: The following is a constructor that takes all attribute values and sets the classes attributes to these values.
        */
        public Employee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN)
        {
            firstName = String.Copy(newFirstName);
            lastName = String.Copy(newLastName);
            dateOfBirth = String.Copy(newDateOfBirth);
            socialInsuranceNumber = String.Copy(newSIN);
        }
        /** Name: ~Employee()
        Params: None
        Use: The following is a destructor for the Employee class
        */
        
        ~Employee()
        {
        }
        /**
        Name: SetFirstName()
        * \brief Mutator used to set the employees first name
        * \param - firstName - <b>string<\b> - represents the employee's first name
        */
        public bool SetFirstName(string newFirstName)
        {

            string tester = string.Empty;   //set an empty string for checking if the name is an empty string

            firstName = newFirstName;

            //validate the first name...
            //check if name is empty string...
            if (firstName.Equals(""))
            {
                //first name is allowed to be empty, return true
                Logger.Log("Employee", "SetFirstName", "First Name is valid.");
                return true;
            }

            //now check each character for validity
            foreach (char c in firstName)
            {
                if (char.IsUpper(c))
                {
                    continue;
                }
                else if (char.IsLower(c))
                {
                    continue;
                }
                else if (c == (char)39)
                {
                    //apostrophe is valid, continue
                    continue;
                }
                else if (c == (char)45)
                {
                    //hyphen or dash is valid, continue...
                    continue;
                }
                else
                {
                    Logger.Log("Employee", "SetFirstName", "First Name is invalid.");
                    firstName = null;
                    return (false);
                }

            }
            Logger.Log("Employee", "SetFirstName", "First Name is valid.");
            return true;
        }

        /**
        * Name: SetlastName()
       * \brief Mutator used to set the employees last name
       * \param - lastName - <b>string<\b> - represents the employee's last name
       */
        public bool SetLastName(string newLastName)
        {
            string tester = string.Empty;

            lastName = newLastName;

            //validate the last name...
            //check if name is empty string...
            if (lastName.Equals(""))
            {
                //last name is allowed to be empty, return true
                Logger.Log("Employee", "SetLastName", "Last Name is valid.");
                return true;
            }

            //now check each character for validity
            foreach (char c in lastName)
            {
                if (char.IsUpper(c))
                {
                    continue;
                }
                else if (char.IsLower(c))
                {
                    continue;
                }
                else if (c == (char)39)
                {
                    //apostrophe is valid, continue
                    continue;
                }
                else if (c == (char)45)
                {
                    //hyphen or dash is valid, continue...
                    continue;
                }
                else
                {
                    Logger.Log("Employee", "SetLastName", "Last Name is invalid.");
                    lastName = null;
                    return (false);
                }

            }
            Logger.Log("Employee", "SetLastName", "Last Name is valid and set.");
            return true;
        }

        /**
        Name: SetdateOfBirth()
        Params: string newBirthDay
    * \brief Mutator used to set the employees dateOfBirth
    */
        public bool SetDateOfBirth(string newBirthDay)
        {
            string temp;
            DateTime result;    
            
            temp = newBirthDay;
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            
            if(temp.Equals("N/A")){
                 Logger.Log("Employee", "SetDateOfBirth", "Date of Birth is valid and set.");
                 dateOfBirth = String.Copy(temp);
                 return (true);
            }
            if(temp.Equals("")){
                 Logger.Log("Employee", "SetDateOfBirth", "Date of Birth is valid and set.");
                 dateOfBirth = String.Copy(temp);
                 return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("Employee", "SetDateOfBirth", "Date of Birth is invalid.");
                return (false);
            }
            dateOfBirth = String.Copy(temp);

            dateOfBirth = dateOfBirth.Insert(4, "-");   //reformat the string for output
            dateOfBirth = dateOfBirth.Insert(7, "-");
            Logger.Log("Employee", "SetDateOfBirth", "Date of Birth is valid and set.");
            return (true);

        }
        /** 
        Name: SetSIN()
        Params: string newSIN
        Use: Method is a mutator used to set the value of the SIN attribute of the employee class. Returns true if valid entry
            false if not.
            */
        public bool SetSIN(string newSIN)
        {
            socialInsuranceNumber = newSIN;

            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length > 9))  //make sure the SIN is a valid length
            {
                Logger.Log("Employee", "SetSIN", "SIN is invalid. Invalid length.");
                return (false);

            }

            //now check that it contains only numbers...
            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Logger.Log("Employee", "SetSIN", "SIN is invalid. Invalid characters within it.");
                    return (false);
                }
            }

            //now can do SIN manipulation...

            //even numbers get multiplied by two and added as single digits. Odds get added. 
            for (intCount = 1; intCount <= 8; intCount++)
            {
                if (intCount % 2 == 0)    //if the intCount is an even number
                {
                    temp1 = (int)Char.GetNumericValue(socialInsuranceNumber[intCount - 1]);
                    temp1 = temp1 * 2;
                    if (temp1 > 9)
                    {
                        intEven = intEven + 1 + (temp1 - 10);
                    }
                    else
                    {
                        intEven = intEven + temp1;
                    }
                }
                if (intCount % 2 != 0)
                {
                    intOdd = intOdd + (int)Char.GetNumericValue(socialInsuranceNumber[intCount - 1]);
                }
            }
            //now add both intEven and intOdd and check to see if is divisible by 10!
            intTotal = intOdd + intEven;
            temp2 = (intTotal / 10) * 10;
            if (temp2 < intTotal)
            {
                temp2 = temp2 + 10;
            }
            intTotal = temp2 - intTotal;

            //check if intTotal is equal to the 9th digit of the SIN, if so, SIN is valid...
            if (intTotal == (int)Char.GetNumericValue(socialInsuranceNumber[8]))
            {
                //SIN is valid
               // LOG CALL


                socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
                socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");
                
                Logger.Log("Employee", "SetSIN", "SIN is valid.");
                return (true);
            }

            Logger.Log("Employee", "SetSIN", "SIN is invalid.");
            socialInsuranceNumber = null;
            return (false);
        }
    }
}

