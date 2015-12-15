using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Supporting;

namespace AllEmployees
{
    
    /**
    Class Name: ParttimeEmployee
    Purpose: This class is a child of the Employee class and contains all attributes and methods specific to the 
            part time employee type. 
    */
    public class ParttimeEmployee : Employee
    {
        string dateOfHire;
        string dateOfTermination;
        double hourlyRate;

        /**
        Name: ParttimeEmployee()
        Params: None
        Use: This method is a default constructor that sets all attribute values of the parttime employee class to zero values.
        */
        public ParttimeEmployee() : base()   //default constructor sets all attributes to null/zero
        {
            dateOfHire = null;
            dateOfTermination = null;
            hourlyRate = 0.0;
        }
          /**
        Name: ParttimeEmployee()
        Params: string _FirstName, string _LastName
        Use: This method is a constructor that takes the first and last name of the employee, sets those values, as well as 
            sets all other class attribute values to zero values.
        */
        public ParttimeEmployee(string _firstName, string _lastName) : base(_firstName, _lastName)    //constructor that takes the first and last name
        {
            dateOfHire = null;
            dateOfTermination = null;
            hourlyRate = 0.0;
        }

         /**
        Name: ParttimeEmployee()
        Params: string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newDateOfHire, string newDateOfTermination, double newHourlyRate
        Use: This method is a constructor that takes in all values for the parttime employee as parameters and sets the attribute values 
            to these inputs.
        */
        public ParttimeEmployee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN,
            string newDateOfHire, string newDateOfTermination, double newHourlyRate)
            : base(newFirstName, newLastName, newDateOfBirth, newSIN)    //constructor taking all attribute values
        {
            dateOfHire = String.Copy(newDateOfHire);
            dateOfTermination = String.Copy(newDateOfTermination);
            hourlyRate = newHourlyRate;
            employeeType = "PT";
        }
        /**
        Name: ~ParttimeEmployee()
        Params: None
        Use: The following is a destructor for the parttime employee class
        */
        ~ParttimeEmployee() //destructor for the parttime employee class
        {
        }

        /**
        Name: SetHourlyRate
        Params: string newRate
        Use: The following method is a mutator for the hourlyRate attribute of the ParttimeEmployee class
        */
        public bool SetHourlyRate(string newRate)
        {
            if (!double.TryParse(newRate, out hourlyRate))
            {
                Logger.Log("ParttimeEmployee", "SetHourlyRate", "Hourly Rate is invalid.");
                return (false);

            }
            double theRate = Convert.ToDouble(newRate);
            if (theRate < 0)
            {
                Logger.Log("ParttimeEmployee", "SetHourlyRate", "Hourly Rate is invalid.");
                return false;
            }
            hourlyRate = theRate;
            Logger.Log("ParttimeEmployee", "SetHourlyRate", "Hourly Rate is valid and set.");
            return true;
        }
        
        /** 
        Name: Details()
        Params: None
        Use: The following method is a string builder that builds and returns a string that provides feedback on 
            what the value of every attribute in the current ParttimeEmployee class is set to.
            */
        public string Details()
        {
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


            Logger.Log("ParttimeEmployee", "Details", theDetails); // log the details
            return (theDetails);
        }

        //date validation for hire and termination follows same as DOB

        /**
        Name: SetDateOfHire
        Params: string newDateOfHire
        Use: The following method is a mutator for the dateOfHire attribute of the ParttimeEmployee Class
        */
        public bool SetDateOfHire(string newDateOfHire)
        {
            string temp = newDateOfHire;
            DateTime result;

            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                 Logger.Log("ParttimeEmployee", "SetDateOfHire", "Date of Hire is invalid.");
                return (false);
            }
            dateOfHire = String.Copy(temp);

            dateOfHire = dateOfHire.Insert(4, "-");
            dateOfHire = dateOfHire.Insert(7, "-");
            Logger.Log("ParttimeEmployee", "SetDateOfHire","Date Of Hire is valid.");
            return true;
        }
        
        /** 
        Name: SetDateOfTermination
        Params: newDateOfTermination
        Use: The following method is a mutator for the dateOfTermination attribute of the ParttimeEmployee class
        */
        public bool SetDateOfTermination(string newDateOfTermination)
        {
            string temp = newDateOfTermination;
            DateTime result;

            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            if (String.Compare("", temp) == 0)
            {
                //allowed to be blank... 
                dateOfTermination = String.Copy(temp);
                Logger.Log("ParttimeEmployee", "SetDateOfTermination", "Date Of Termination is valid.");
                return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("ParttimeEmployee", "SetDateOfTermination", "Date Of Termination is invalid.");
                return (false);
            }
            dateOfTermination = String.Copy(temp);

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");
            Logger.Log("ParttimeEmployee", "SetDateOfTermination", "Date Of Termination is valid.");
            return true;
        }

        /**
        Name: Validate
        Params: None
        Use: The following method is used to validate all attributes of the ParttimeEmployee class to the requirements of 
            what a parttime employee must have to be stored within the company. If any value comes back as invalid the 
            method will return false. Only if all attributes come back as valid will it return true.
            */
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
                    Logger.Log("ParttimeEmployee", "Validate", "First Name is invalid");
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
                    Logger.Log("ParttimeEmployee", "Validate", "Last Name is invalid");
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
                Logger.Log("ParttimeEmployee", "Validate", "SIN # is invalid, length is incorrect");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Logger.Log("ParttimeEmployee", "Validate", "SIN # invalid, contains illegal characters");
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
                Logger.Log("ParttimeEmployee", "Validate", "SIN # is invalid, does not adhere to SIN # protocol");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");


            //now validate Date of birth

            DateTime result;


            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("ParttimeEmployee", "Validate", "Date of Birth is invalid, not a real date.");
                return (false);
            }


            dateOfBirth = dateOfBirth.Insert(4, "-");
            dateOfBirth = dateOfBirth.Insert(7, "-");

            //now validate date of hire 

            dateOfHire = Regex.Replace(dateOfHire, @"-+", ""); //removes all whitespace from the inputted date

            if (!DateTime.TryParseExact(dateOfHire, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("ParttimeEmployee", "Validate", "Date of Hire is invalid, not a real date.");
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
                Logger.Log("ParttimeEmployee", "Validate", "Date of Termination is invalid, not a real date");
                return (false);
            }

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");

            //validate salary
            if (hourlyRate <= 0.0)
            {
                Logger.Log("ParttimeEmployee", "Validate", "Hourly Rate is invalid, cannot be less than or equal to zero");
                return (false);
            }
            Logger.Log("ParttimeEmployee", "Validate", "All Attributes are valid.");
            return (true);
        }

    }
}
