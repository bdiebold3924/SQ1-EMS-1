using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
/// \class library called AllEmployees
/// \brief purpose of this library is to contain the 5 employee type classes needed for EMS-1



namespace AllEmployeees
{
    public class Employee
    {
        /* ATTRIBUTES */

        public string firstName; ///< first name of the employee, stored as a string
        public string lastName;  ///< last name of the employee stored as a string
        public string dateOfBirth; ///< date of birth will be stored as a string
        public string socialInsuranceNumber;  ///< 9 digit number that will be stored as a string

        public string employeeType;  ///< To be used to keep track of which employee type we are currently working with




       public Employee()    //default constructor
        {
            firstName = null;
            lastName = null;
            dateOfBirth = null;
            socialInsuranceNumber = null;

        }

        public Employee(string _firstName, string _lastName)    //constructor that takes names 
        {
            firstName = String.Copy(_firstName);
            lastName = String.Copy(_lastName);

            dateOfBirth = null;
            socialInsuranceNumber = null;
        }

        public Employee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN)
        {
            firstName = String.Copy(newFirstName);
            lastName = String.Copy(newLastName);
            dateOfBirth = String.Copy(newDateOfBirth);
            socialInsuranceNumber = String.Copy(newSIN);
        }

        ~Employee()
        {
            Console.WriteLine("Employee parent class cleaned and destroyed.");
        }
        /**
        * \brief Mutator used to set the employees first name
        * \param - firstName - <b>string<\b> - represents the employee's first name
        */
        public bool SetFirstName()
        {

            string tester = string.Empty;

            Console.Write("Enter the employee's first name.");
            firstName = Console.ReadLine();

            //validate the first name...
            //check if name is empty string...
            if (firstName.Equals(""))
            {
                //first name is allowed to be empty, return true
                Console.Write("Valid Name");
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
                    Console.Write("Invalid first name...");
                    firstName = null;
                    return (false);
                }

            }
            Console.WriteLine("First Name is Valid.");
            return true;
        }

        /**
       * \brief Mutator used to set the employees last name
       * \param - lastName - <b>string<\b> - represents the employee's last name
       */
        public bool setLastName()
        {
            string tester = string.Empty;

            Console.WriteLine("Enter the employee's last name.");

            lastName = Console.ReadLine();

            //validate the last name...
            //check if name is empty string...
            if (lastName.Equals(""))
            {
                //last name is allowed to be empty, return true
                Console.Write("Valid Last Name");
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
                    Console.Write("Invalid last name...");
                    lastName = null;
                    return (false);
                }

            }
            Console.WriteLine("last Name is Valid.");
            return true;
        }

        /**
    * \brief Mutator used to set the employees dateOfBirth
    */
        public bool setDateOfBirth()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of birth (YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date

           // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result)){
                Console.WriteLine("Invalid date.");
                return (false);
            }
            dateOfBirth = String.Copy(temp);

            dateOfBirth = dateOfBirth.Insert(4, "-");
            dateOfBirth = dateOfBirth.Insert(7, "-");
          //  Console.WriteLine(dateOfBirth);          
            return (true);
   
        }




        public bool setSIN()
        {
            Console.WriteLine("Enter the employee's 9 digit SIN number");
            socialInsuranceNumber = Console.ReadLine();

            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length > 9))
            {
                return (false);

            }

            //now check that it contains only numbers...
            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    return (false);
                }
            }

            //now can do SIN manipulation...

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
                Console.WriteLine("Valid SIN.");

                Console.WriteLine(socialInsuranceNumber);

                socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
                socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");

                Console.WriteLine(socialInsuranceNumber);

                return (true);
            }

            Console.WriteLine("Invalid SIN");
            socialInsuranceNumber = null;
            return (false);
        }



    }
    class FulltimeEmployee : Employee
    {

        string dateOfHire;
        string dateOfTermination;
        int salary;

        public FulltimeEmployee()   //default constructor sets all attributes to zero
        {
            dateOfHire = null;
            dateOfTermination = null;
            salary = 0;
        }

        public FulltimeEmployee(string _firstName, string _lastName)  //constructor that takes the employees first and last name
        {
            dateOfHire = null;
            dateOfTermination = null;
            salary = 0;

            firstName = String.Copy(_firstName);
            lastName = String.Copy(_lastName);

        }

        public FulltimeEmployee(string newDateOfHire, string newDateOfTermination, int newSalary)   //constructor that takes all attributes
        {
            dateOfHire = String.Copy(newDateOfHire);
            dateOfTermination = String.Copy(newDateOfTermination);
            salary = newSalary;
        }

        public bool setSalary()
        {
            int newSalary = 0;
            string input = null;
            Console.WriteLine("Enter the salary for the employee");
            input = Console.ReadLine();

            foreach (char c in input)
            {
                if (Char.IsDigit(c) == false)
                {
                    Console.WriteLine("Invalid salary input.");
                    return (false);
                }
            }

            newSalary = Convert.ToInt32(input);
            if (newSalary <= 0)
            {
                Console.WriteLine("Invalid salary input.");
                return (false);
            }
            return (true);
        }

        //set date of hire and date of termination methods.. follow the same date validation as DOB
        public bool setDateOfHire()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            dateOfHire = String.Copy(temp);

            dateOfHire = dateOfHire.Insert(4, "-");
            dateOfHire = dateOfHire.Insert(7, "-");

            return true;
        }

        public bool setDateOfTermination()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            if(String.Compare("", temp) == 0)
            {
                //allowed to be blank... 
                dateOfTermination = String.Copy(temp);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            dateOfTermination = String.Copy(temp);

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            return true;
        }

        public bool Validate()
        {
            //first validate first name... 
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
                    Console.Write("Invalid first name.");
                    return (false);
                }

            }

            //now check lastName for validity 
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
                    Console.Write("Invalid last name.");
                    return (false);
                }
            }


            //now check SIN number... 
            socialInsuranceNumber = Regex.Replace(socialInsuranceNumber, @"\s+", ""); //removes all whitespace from the SIN
            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length < 9) || (socialInsuranceNumber.Length > 9))
            {
                Console.WriteLine("Invalid SIN number.");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Invalid SIN number.");
                    return (false);
                }
            }

            //now can do SIN manipulation...

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
            if (intTotal != (int)Char.GetNumericValue(socialInsuranceNumber[8]))
            {



                // Console.WriteLine(socialInsuranceNumber);
                Console.WriteLine("Invalid SIN number.");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");


            //now validate Date of birth
         
            DateTime result;

          
            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of birth.");
                return (false);
            }
            

            dateOfBirth = dateOfBirth.Insert(4, "-");
            dateOfBirth = dateOfBirth.Insert(7, "-");
            //  Console.WriteLine(dateOfBirth);          

            //now validate date of hire 
   
            dateOfHire = Regex.Replace(dateOfHire, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfHire, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of hire.");
                return (false);
            }
          

            dateOfHire = dateOfHire.Insert(4, "-");
            dateOfHire = dateOfHire.Insert(7, "-");

            //now validate date of termination
            int blankFlag = 0;
            dateOfTermination = Regex.Replace(dateOfTermination, @"-+", ""); //removes all whitespace from the inputted date
            if (String.Compare("", dateOfTermination) == 0)
            {
                //allowed to be blank... 

                blankFlag = 1;
            }
            else if (!DateTime.TryParseExact(dateOfTermination, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0)
            {
                Console.WriteLine("Invalid date of termination.");
                return (false);
            }

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            //validate salary
            if(salary <= 0)
            {
                Console.WriteLine("Invalid Salary");
                return (false);
            }
            return (true);
        }


        public void Details()
        {
            Console.WriteLine("Employee Details: ");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Date of Birth: " + dateOfBirth);
            Console.WriteLine("SIN: " + socialInsuranceNumber);
            Console.WriteLine("Date of Hire: " + dateOfHire);
            Console.WriteLine("Date of termination " + dateOfTermination);
            Console.WriteLine("Salary: " + salary);
        }
        ~FulltimeEmployee()     //destructor for the FullTimeEmployee class
        {
            Console.WriteLine("FullTime employee cleaned and destroyed.");
        }


    }
    //end of FullTimeEmployee





    //Start of ParttimeEmployee
    class ParttimeEmployee : Employee
    {
        string dateOfHire;
        string dateOfTermination;
        double hourlyRate;

        public ParttimeEmployee()   //default constructor sets all attributes to null/zero
        {
            dateOfHire = null;
            dateOfTermination = null;
            hourlyRate = 0.0;
        }

        public ParttimeEmployee(string _FirstName, string _LastName)    //constructor that takes the first and last name
        {
            dateOfHire = null;
            dateOfTermination = null;
            hourlyRate = 0.0;

            firstName = String.Copy(_FirstName);
            lastName = String.Copy(_LastName);
        }

        public ParttimeEmployee(string newDateOfHire, string newDateOfTermination, double newHourlyRate)    //constructor taking all attribute values
        {
            dateOfHire = String.Copy(newDateOfHire);
            dateOfTermination = String.Copy(newDateOfTermination);
            hourlyRate = newHourlyRate;
        }

        ~ParttimeEmployee() //destructor for the parttime employee class
        {
            Console.WriteLine("Parttime employee cleaned and destroyed.");
        }

        public bool setHourlyRate()
        {
            Console.WriteLine("Enter the employees hourly rate as a decimal value. (ie 10.00)");
            if (!double.TryParse(Console.ReadLine(), out hourlyRate))
            {
                Console.WriteLine("Invalid hourly rate input");
                return (false);

            }
           // Console.WriteLine(hourlyRate);

            return true;
        }

        public void Details()
        {
            Console.WriteLine("Employee Details: ");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Date of Birth: " + dateOfBirth);
            Console.WriteLine("SIN: " + socialInsuranceNumber);
            Console.WriteLine("Date of Hire: " + dateOfHire);
            Console.WriteLine("Date of termination " + dateOfTermination);
            Console.WriteLine("Hourly Rate: " + hourlyRate);
        }

        //date validation for hire and termination follows same as DOB

        public bool setDateOfHire()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            dateOfHire = String.Copy(temp);

            dateOfHire = dateOfHire.Insert(4, "-");
            dateOfHire = dateOfHire.Insert(7, "-");

            return true;
        }
        public bool setDateOfTermination()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            if (String.Compare("", temp) == 0)
            {
                //allowed to be blank... 
                dateOfTermination = String.Copy(temp);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            dateOfTermination = String.Copy(temp);

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            return true;
        }

        public bool Validate()
        {
            //first validate first name... 
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
                    Console.Write("Invalid first name.");
                    return (false);
                }

            }

            //now check lastName for validity 
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
                    Console.Write("Invalid last name.");
                    return (false);
                }
            }


            //now check SIN number... 
            socialInsuranceNumber = Regex.Replace(socialInsuranceNumber, @"\s+", ""); //removes all whitespace from the SIN
            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length < 9) || (socialInsuranceNumber.Length > 9))
            {
                Console.WriteLine("Invalid SIN number.");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Invalid SIN number.");
                    return (false);
                }
            }

            //now can do SIN manipulation...

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
            if (intTotal != (int)Char.GetNumericValue(socialInsuranceNumber[8]))
            {



                // Console.WriteLine(socialInsuranceNumber);
                Console.WriteLine("Invalid SIN number.");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");


            //now validate Date of birth

            DateTime result;


            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of birth.");
                return (false);
            }


            dateOfBirth = dateOfBirth.Insert(4, "-");
            dateOfBirth = dateOfBirth.Insert(7, "-");
            //  Console.WriteLine(dateOfBirth);          

            //now validate date of hire 

            dateOfHire = Regex.Replace(dateOfHire, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfHire, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of hire.");
                return (false);
            }


            dateOfHire = dateOfHire.Insert(4, "-");
            dateOfHire = dateOfHire.Insert(7, "-");

            //now validate date of termination
            int blankFlag = 0;
            dateOfTermination = Regex.Replace(dateOfTermination, @"-+", ""); //removes all whitespace from the inputted date
            if (String.Compare("", dateOfTermination) == 0)
            {
                //allowed to be blank... 

                blankFlag = 1;
            }
            else if (!DateTime.TryParseExact(dateOfTermination, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0)
            {
                Console.WriteLine("Invalid date of termination.");
                return (false);
            }

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            //validate salary
            if (hourlyRate <= 0.0)
            {
                Console.WriteLine("Invalid Hourly Rate");
                return (false);
            }
            return (true);
        }

    }
    //end of part time employee



        //start of contract employee
    class ContractEmployee : Employee
    {
        string contractStartDate;
        string contractStopDate;
        int fixedContractAmount;

        //SIN for this class holds a Business number... 
        //last name for this class is nothing, last name is the corporations name
        //base date of birth for employees in this class must hold the date of incorporation

        public ContractEmployee()   //default constructor sets all attributes to zero
        {
            contractStartDate = null;
            contractStopDate = null;
            fixedContractAmount = 0;

        }

        public ContractEmployee(string _lastName)   //constructor that takes last name.. first name is always blank in this case
        {
            contractStartDate = null;
            contractStopDate = null;
            fixedContractAmount = 0;

            lastName = String.Copy(_lastName);
            firstName = "";


        }

        public ContractEmployee(string newContractStartDate, string newContractStopDate, int newFixedContractAmount)
        {
            contractStartDate = String.Copy(newContractStartDate);
            contractStopDate = String.Copy(newContractStopDate);
            fixedContractAmount = newFixedContractAmount;
        }

        ~ContractEmployee()     //destructor for the contract employee class
        {
            Console.WriteLine("Contract Employee cleaned and destroyed");
        }

        //hourlyRate mutator..
        public bool setFixedContractAmount()
        {
            Console.WriteLine("Enter the employee's fixed contract amount.");
            if (!int.TryParse(Console.ReadLine(), out fixedContractAmount))
            {
                Console.WriteLine("Invalid fixed contract amount input");
                return (false);

            }
            return (true);
        }

        public void Details()
        {
            Console.WriteLine("Employee Details: ");
            Console.WriteLine("Company Name: " + lastName);
            Console.WriteLine("Date of Incorporation: " + dateOfBirth);
            Console.WriteLine("Business Number: " + socialInsuranceNumber);
            Console.WriteLine("Contract Start Date: " + contractStartDate);
            Console.WriteLine("Contract Stop Date: " + contractStopDate);
            Console.WriteLine("Fixed Contract Amount ($): " + fixedContractAmount);
        }
        //contract start and stop dates are next here... business number validation of SIN is next up in validation...

        public bool setContractStartDate()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            contractStartDate = String.Copy(temp);

            contractStartDate = contractStartDate.Insert(4, "-");
            contractStartDate = contractStartDate.Insert(7, "-");

            return true;
        }
        public bool setContractStopDate()
        {
            string temp;
            DateTime result;

            Console.WriteLine("Enter the date of hire. YYYY-MM-DD");
            temp = Console.ReadLine();
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            if (String.Compare("", temp) == 0)
            {
                //allowed to be blank... 
                contractStopDate = String.Copy(temp);
                return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date.");
                return (false);
            }
            contractStopDate = String.Copy(temp);

            contractStopDate = contractStopDate.Insert(4, "-");
            contractStopDate = contractStopDate.Insert(7, "-");

            return true;
        }

        public bool Validate()
        {
            
            //now check lastName for validity ... stands for company name
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
                    Console.Write("Invalid last name.");
                    return (false);
                }
            }


            //now check SIN number... 
            socialInsuranceNumber = Regex.Replace(socialInsuranceNumber, @"\s+", ""); //removes all whitespace from the SIN
            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length < 9) || (socialInsuranceNumber.Length > 9))
            {
                Console.WriteLine("Invalid SIN number.");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Invalid SIN number.");
                    return (false);
                }
            }

            //now can do SIN manipulation...

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
            if (intTotal != (int)Char.GetNumericValue(socialInsuranceNumber[8]))
            {

                // Console.WriteLine(socialInsuranceNumber);
                Console.WriteLine("Invalid BN.");
                return (false);
            }
            if((int)Char.GetNumericValue(socialInsuranceNumber[0]) != (int)Char.GetNumericValue(dateOfBirth[2]))
            {
                Console.WriteLine("Invalid Business Number, 1st number does not match company year");
                return (false);
            }
            if((int)Char.GetNumericValue(socialInsuranceNumber[1]) != (int)Char.GetNumericValue(dateOfBirth[3]))
            {
                Console.WriteLine("Invalid Business Number, 2nd number does not match the company year.");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(5, " ");   //formats the output accordingly
           

            //now validate Date of birth... stands for date of incorporation

            DateTime result;

            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of birth.");
                return (false);
            }


            dateOfBirth = dateOfBirth.Insert(4, "-");
            dateOfBirth = dateOfBirth.Insert(7, "-");
            //  Console.WriteLine(dateOfBirth);          
            //now validate contract start date

            contractStartDate = Regex.Replace(contractStartDate, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(contractStartDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Invalid date of hire.");
                return (false);
            }


            contractStartDate = contractStartDate.Insert(4, "-");
            contractStartDate = contractStartDate.Insert(7, "-");

            //now validate date of termination
            int blankFlag = 0;
            contractStopDate = Regex.Replace(contractStopDate, @"-+", ""); //removes all whitespace from the inputted date
           
            if (!DateTime.TryParseExact(contractStopDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0)
            {
                Console.WriteLine("Invalid date of termination.");
                return (false);
            }

           contractStopDate = contractStopDate.Insert(4, "-");
            contractStopDate = contractStopDate.Insert(7, "-");

            //validate salary
            if (fixedContractAmount <= 0)
            {
                Console.WriteLine("Invalid Salary");
                return (false);
            }
            return (true);
        }


    }

    class SeasonalEmployee : Employee
    {
        string season; //includes Winter Spring Summer Fall
        double piecePay;

        public SeasonalEmployee()   //default constructor
        {
            season = null;
            piecePay = 0.0;

        }

        public SeasonalEmployee(string _firstName, string _lastName)
        {
            season = null;
            piecePay = 0.0;

            firstName = String.Copy(_firstName);
            lastName = String.Copy(_lastName);

        }

        public SeasonalEmployee(string newSeason, double newPiecePay)
        {
            if (String.Compare("winter", newSeason) == 0)
            {
                season = String.Copy(newSeason);
            }
            else if (String.Compare("spring", newSeason) == 0)
            {
                season = String.Copy(newSeason);
            }
            else if (String.Compare("summer", newSeason) == 0)
            {
                season = String.Copy(newSeason);
            }
            else if(String.Compare("fall", newSeason) == 0)
            {
                season = String.Copy(newSeason);
            }
            else
            {
                season = "";
            }

            piecePay = newPiecePay;
        }
        
        public bool setSeason() //mutator for the season attribute
        {
            string temp = null;
            Console.WriteLine("Enter the season the employee is working in");
            temp = Console.ReadLine();
            temp = temp.ToLower();
            //now check to see if the season inputted was valid and if so make it the official season for the attribute
            if (String.Compare("winter", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else if (String.Compare("spring", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else if (String.Compare("summer", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else if (String.Compare("fall", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else if(String.Compare("", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else
            {
                Console.WriteLine("Invalid input for the employee's season of work.");
                return (false);
            }
            return (true);
        }

        public bool setPiecePay()   //mutator for the seasonal piece pay value 
        {
            Console.WriteLine("Enter the seasonal employee's piece pay.");

            if (!double.TryParse(Console.ReadLine(), out piecePay))
            {
                Console.WriteLine("Invalid piece pay input");
                return (false);

            }
            return (true);
        }

        public void Details()
        {
            Console.WriteLine("Employee Details: ");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Date of Birth: " + dateOfBirth);
            Console.WriteLine("SIN: " + socialInsuranceNumber);
            Console.WriteLine("Season: " + season);
            Console.WriteLine("Piece Pay ($/piece): " + piecePay);
        }
        public bool Validate()
        {
            //first validate first name... 
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
                    Console.Write("Invalid first name.");
                    return (false);
                }

            }

            //now check lastName for validity 
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
                    Console.Write("Invalid last name.");
                    return (false);
                }
            }


            //now check SIN number... 
            socialInsuranceNumber = Regex.Replace(socialInsuranceNumber, @"\s+", ""); //removes all whitespace from the SIN
            int intCount = 0;
            int intEven = 0;
            int intOdd = 0;
            int intTotal = 0;

            int temp1 = 0;
            int temp2 = 0;


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length < 9) || (socialInsuranceNumber.Length > 9))
            {
                Console.WriteLine("Invalid SIN number.");
                return (false);

            }
            
            //now check that it contains only numbers...

 
            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Invalid SIN number.");
                    return (false);
                }
            }

            //now can do SIN manipulation...

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
            if (intTotal != (int)Char.GetNumericValue(socialInsuranceNumber[8]))
            {
        
               

                // Console.WriteLine(socialInsuranceNumber);
                Console.WriteLine("Invalid SIN number.");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");

            //now check for valid season value..
             
            if (String.Compare("winter", season) != 0)
            {
                Console.WriteLine("Invalid season");
                return (false);
            }
            else if (String.Compare("spring", season) != 0)
            {
                Console.WriteLine("Invalid season");
                return (false);
            }
            else if (String.Compare("summer", season) != 0)
            {
                Console.WriteLine("Invalid season");
                return (false);
            }
            else if (String.Compare("fall", season) != 0)
            {
                Console.WriteLine("Invalid season");
                return (false);
            }
            else if (String.Compare("", season) != 0)
            {
                Console.WriteLine("Invalid season");
                return (false);
            }
          
            //now validate piece pay
            if(piecePay <= 0.0)
            {
                Console.WriteLine("Invalid Piece pay");
                return (false);
            }
            

            //now validate Date of birth

            return (true);
        }

        ~SeasonalEmployee() //destructor for the seasonal employee
        {
            Console.WriteLine("Seasonal employee class cleaned and destroyed");
        }
    }
}

