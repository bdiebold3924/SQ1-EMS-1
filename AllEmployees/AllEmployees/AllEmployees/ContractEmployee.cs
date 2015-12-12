using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AllEmployees
{
    public class ContractEmployee : Employee
    {
        string contractStartDate;
        string contractStopDate;
        int fixedContractAmount;

        //SIN for this class holds a Business number... 
        //first name for this class is nothing, last name is the corporations name
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

        public ContractEmployee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newContractStartDate, string newContractStopDate, int newFixedContractAmount)
        {
            contractStartDate = String.Copy(newContractStartDate);
            contractStopDate = String.Copy(newContractStopDate);
            fixedContractAmount = newFixedContractAmount;
            employeeType = "CT";
        }

        ~ContractEmployee()     //destructor for the contract employee class
        {
            // Console.WriteLine("Contract Employee cleaned and destroyed");
        }

        //hourlyRate mutator..
        public bool setFixedContractAmount()
        {
            Console.WriteLine("Enter the employee's fixed contract amount.");
            if (!int.TryParse(Console.ReadLine(), out fixedContractAmount))
            {
                // LOG CALL    Console.WriteLine("Invalid fixed contract amount input");
                return (false);

            }
            return (true);
        }

        public string Details()
        {

            // string builder that builds the full output details of every attribute of the current employee object


            /* Console.WriteLine("Employee Details: ");
               Console.WriteLine("Company Name: " + lastName);
               Console.WriteLine("Date of Incorporation: " + dateOfBirth);
               Console.WriteLine("Business Number: " + socialInsuranceNumber);
               Console.WriteLine("Contract Start Date: " + contractStartDate);
               Console.WriteLine("Contract Stop Date: " + contractStopDate);
               Console.WriteLine("Fixed Contract Amount ($): " + fixedContractAmount); */
            //  string theDetails = ("Employee Details:\n Company Name: " + lastName + " ")

            string theDetails = "Employee Details:\n";

            theDetails = String.Concat(theDetails, "Company Name: ");
            theDetails = String.Concat(theDetails, lastName);

            theDetails += Environment.NewLine;

            theDetails += "Date of Incorporation: ";
            theDetails += dateOfBirth;
            theDetails += Environment.NewLine;

            theDetails += "Business Number: ";
            theDetails += socialInsuranceNumber;
            theDetails += Environment.NewLine;

            theDetails += "Contract Start Date: ";
            theDetails += contractStartDate;
            theDetails += Environment.NewLine;

            theDetails += "Contract Stop Date: ";
            theDetails += contractStopDate;
            theDetails += Environment.NewLine;

            theDetails += "Fixed Contract Amount($): ";
            theDetails += fixedContractAmount;
            theDetails += Environment.NewLine;


            return (theDetails);
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
                //LOG CALL     Console.WriteLine("Invalid date.");
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
                //LOG CALL Console.WriteLine("Invalid date.");
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
                    //LOG CALL Console.Write("Invalid last name.");
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
                //LOG CALL Console.WriteLine("Invalid SIN number.");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    //LOG CALL Console.WriteLine("Invalid SIN number.");
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
                //LOG CALL  Console.WriteLine("Invalid BN.");
                return (false);
            }
            if ((int)Char.GetNumericValue(socialInsuranceNumber[0]) != (int)Char.GetNumericValue(dateOfBirth[2]))
            {
                //LOG CALL     Console.WriteLine("Invalid Business Number, 1st number does not match company year");
                return (false);
            }
            if ((int)Char.GetNumericValue(socialInsuranceNumber[1]) != (int)Char.GetNumericValue(dateOfBirth[3]))
            {
                //LOG CALL Console.WriteLine("Invalid Business Number, 2nd number does not match the company year.");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(5, " ");   //formats the output accordingly


            //now validate Date of birth... stands for date of incorporation

            DateTime result;

            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            // Console.WriteLine(temp);
            if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                //LOG CALL Console.WriteLine("Invalid date of birth.");
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
                // LOG CALL Console.WriteLine("Invalid date of hire.");
                return (false);
            }


            contractStartDate = contractStartDate.Insert(4, "-");
            contractStartDate = contractStartDate.Insert(7, "-");

            //now validate date of termination
            int blankFlag = 0;
            contractStopDate = Regex.Replace(contractStopDate, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(contractStopDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0)
            {
                //LOG CALL Console.WriteLine("Invalid date of termination.");
                return (false);
            }

            contractStopDate = contractStopDate.Insert(4, "-");
            contractStopDate = contractStopDate.Insert(7, "-");

            //validate salary
            if (fixedContractAmount <= 0)
            {
                // LOG CALL Console.WriteLine("Invalid Salary");
                return (false);
            }
            return (true);
        }


    }
}
