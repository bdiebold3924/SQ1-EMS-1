using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AllEmployees
{
    public class ParttimeEmployee : Employee
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

        public ParttimeEmployee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newDateOfHire, string newDateOfTermination, double newHourlyRate)    //constructor taking all attribute values
        {
            dateOfHire = String.Copy(newDateOfHire);
            dateOfTermination = String.Copy(newDateOfTermination);
            hourlyRate = newHourlyRate;
            employeeType = "PT";
        }

        ~ParttimeEmployee() //destructor for the parttime employee class
        {
            //Console.WriteLine("Parttime employee cleaned and destroyed.");
        }

        public bool setHourlyRate()
        {
            Console.WriteLine("Enter the employees hourly rate as a decimal value. (ie 10.00)");
            if (!double.TryParse(Console.ReadLine(), out hourlyRate))
            {
                // LOG CALL Console.WriteLine("Invalid hourly rate input");
                return (false);

            }
            // Console.WriteLine(hourlyRate);

            return true;
        }

        public string Details()
        {
            /*Console.WriteLine("Employee Details: ");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Date of Birth: " + dateOfBirth);
            Console.WriteLine("SIN: " + socialInsuranceNumber);
            Console.WriteLine("Date of Hire: " + dateOfHire);
            Console.WriteLine("Date of termination " + dateOfTermination);
            Console.WriteLine("Hourly Rate: " + hourlyRate);*/

            string theDetails = "Employee Details:\n";

            theDetails = String.Concat(theDetails, "First Name: ");
            theDetails = String.Concat(theDetails, firstName);
            theDetails += Environment.NewLine;

            theDetails += "Last Name: ";
            theDetails += lastName;
            theDetails += Environment.NewLine;

            theDetails += "Date Of Birth: ";
            theDetails += dateOfBirth;
            theDetails += Environment.NewLine;

            theDetails += "Social Insurance Number: ";
            theDetails += socialInsuranceNumber; ;
            theDetails += Environment.NewLine;

            theDetails += "Date of Hire: ";
            theDetails += dateOfHire;
            theDetails += Environment.NewLine;

            theDetails += "Date of Termination: ";
            theDetails += dateOfTermination;
            theDetails += Environment.NewLine;

            theDetails += "Hourly Rate: ";
            theDetails += hourlyRate;
            theDetails += Environment.NewLine;



            return (theDetails);
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
                // LOG CALL Console.WriteLine("Invalid date.");
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
                //LOG CALL Console.WriteLine("Invalid date.");
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
                    //LOG CALL
                    //Console.Write("Invalid first name.");
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
                    //LOG CALL  Console.Write("Invalid last name.");
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
                // LOG CALL Console.WriteLine("Invalid SIN number.");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    // LOG CALL Console.WriteLine("Invalid SIN number.");
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
                // LOG CALL Console.WriteLine("Invalid SIN number.");
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
                //LOG CALL   Console.WriteLine("Invalid date of birth.");
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
                //LOG CALL  Console.WriteLine("Invalid date of hire.");
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
                //LOG CALL    Console.WriteLine("Invalid date of termination.");
                return (false);
            }

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            //validate salary
            if (hourlyRate <= 0.0)
            {
                // LOG CALL Console.WriteLine("Invalid Hourly Rate");
                return (false);
            }
            return (true);
        }

    }
}
