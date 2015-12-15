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
    /** Class Name: FulltimeEmployee
    Purpose: This class is a child class to the Employee class and contains all attributes and methods 
            specific to the Fulltime Employee type.
        */ 
    public class FulltimeEmployee : Employee
    {

        string dateOfHire;
        string dateOfTermination;
        double salary;
        
        /** Name: FulltimeEmployee()
        Params: None
        Use: This is a default constructor that sets all class attributes to zero values.
        */
        public FulltimeEmployee() : base()   //default constructor sets all attributes to zero
        {
            dateOfHire = null;
            dateOfTermination = null;
            salary = 0;
        }
        
        /** Name: FulltimeEmployee()
        Params: string _firstName, string _lastName
        Use: This is a constructor that takes the employees first and last name, sets them, and sets all other class attributes 
            to zero values.
        */
        public FulltimeEmployee(string _firstName, string _lastName) : base(_firstName, _lastName)  //constructor that takes the employees first and last name
        {
            dateOfHire = null;
            dateOfTermination = null;
            salary = 0;

        }
          /** Name: FulltimeEmployee()
        Params: string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newDateOfHire, string newDateOfTermination, int newSalary
        Use: This is a constructor that takes all employee attributes as parameters and class attributes and assigns them these entered values.
        */
        public FulltimeEmployee(string newFirstName, string newLastName, string newDateOfBirth,
            string newSIN, string newDateOfHire, string newDateOfTermination, double newSalary)
            : base(newFirstName, newLastName, newDateOfBirth, newSIN)//constructor that takes all attributes
        {
            dateOfHire = String.Copy(newDateOfHire);
            dateOfTermination = String.Copy(newDateOfTermination);
            salary = newSalary;
            employeeType = "FT";
        }
        
        /** 
        Name: SetSalary
        Params: string newSalary
        Purpose: The following method is a mutator for the salary attribute of the FullTimeEmployee Class
        */
        public bool SetSalary(string newSalary)
        {
            int tmpSal = 0;

            foreach (char c in newSalary)   //check to see the entry is only numbers
            {
                if (Char.IsDigit(c) == false)
                {
                    Logger.Log("FullTimeEmployee", "SetSalary","Salary is invalid, contains invalid characters");
                    return (false);
                }
            }

            tmpSal = Convert.ToInt32(newSalary);
            if (tmpSal < 0)
            {
                Logger.Log("FullTimeEmployee", "SetSalary","Salary is invalid, salary is less than or equal to zero");
                return (false);
            }
            Logger.Log("FullTimeEmployee", "SetSalary","Salary is valid");
            return (true);
        }

        //set date of hire and date of termination methods.. follow the same date validation as DOB
        
        /**
        Name: SetDateOfHire
        Params: string newDateOfHire
        Use: The following is a mutator method for the DateOfHire attribute of the FulltimeEmployee class
        */
        public bool SetDateOfHire(string newDateOfHire)
        {
            string temp = newDateOfHire;
            DateTime result;

            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            //checks to see if the entered string is a valid date
            
            if(temp.Equals("N/A")){
                 Logger.Log("FulltimeEmployee", "SetDateOfHire", "Date of hire is valid and set.");
                 dateOfHire = String.Copy(temp);
                 return (true);
            }
            if(temp.Equals("")){
                 Logger.Log("FulltimeEmployee", "SetDateOfHire", "Date of hire is valid and set.");
                 dateOfHire = String.Copy(temp);
                 return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("FullTimeEmployee", "SetDateOfHire","Date of Hire is invalid.");
                return (false);
            }
            dateOfHire = String.Copy(temp);

            dateOfHire = dateOfHire.Insert(4, "-"); //reformat the string for output
            dateOfHire = dateOfHire.Insert(7, "-");
            Logger.Log("FullTimeEmployee", "SetDateOfHire","Date of Hire is valid.");
            return true;
        }

     /**
        Name: SetDateOfTermination
        Params: string newDateOfTermination
        Use: The following is a mutator method for the DateOfTermination attribute of the FulltimeEmployee class
        */
        public bool SetDateOfTermination(string newDateOfTermination)
        {
            string temp = newDateOfTermination;
            DateTime result;
            
            //follows the same date checking algorithm as previous method
            
            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            
            if(temp.Equals("N/A")){
                 Logger.Log("FulltimeEmployee", "SetDateOfTermination", "Date of termination is valid and set.");
                 dateOfTermination = String.Copy(temp);
                 return (true);
            }
            if (String.Compare("", temp) == 0)
            {
                //allowed to be blank... 
                dateOfTermination = String.Copy(temp);
                return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("FullTimeEmployee", "SetDateOfTermination","Date of termination is invalid.");
                return (false);
            }
            dateOfTermination = String.Copy(temp);

            dateOfTermination = dateOfTermination.Insert(4, "-");
            dateOfTermination = dateOfTermination.Insert(7, "-");
            Logger.Log("FullTimeEmployee", "SetDateOfTermination","Date of Termination is valid.");
            return true;
        }

    /**
        Name: Validate
        Params: None
        Use: The following is a method that checks to see if all attributes for the Fulltime Employee are valid
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
                    Logger.Log("FullTimeEmployee", "Validate()","firstName is invalid");
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
                    Logger.Log("FullTimeEmployee", "Validate()","lastName is invalid");
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
                Logger.Log("FullTimeEmployee", "Validate()","SIN # is invalid");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Logger.Log("FullTimeEmployee", "Validate()","SIN # is invalid");
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
                Logger.Log("FullTimeEmployee", "Validate()","SIN # is invalid");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");


            //now validate Date of birth

            DateTime result;


            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

            if(dateOfBirth != "N/A"){
                if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                {
                    Logger.Log("FulltimeEmployee", "Validate", "date of birth is invalid");   //log the change 
                    return (false);
                }
            }
        
            if(dateOfBirth.Length > 3)
            {
                dateOfBirth = dateOfBirth.Insert(4, "-");
                dateOfBirth = dateOfBirth.Insert(7, "-");  //reformat the string for output purposes 
            }

            //now validate date of hire 

            dateOfHire = Regex.Replace(dateOfHire, @"-+", ""); //removes all whitespace from the inputted date

            if(dateOfHire != "N/A"){
                if ((!DateTime.TryParseExact(dateOfHire, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result)) && (dateOfHire != "N/A"))
                {
                    Logger.Log("FullTimeEmployee", "Validate()","Date Of Hire is invalid");
                    return (false);
                }
            }
            
            if(dateOfHire.Length > 5){
                dateOfHire = dateOfHire.Insert(4, "-");
                dateOfHire = dateOfHire.Insert(7, "-");
            }
            //now validate date of termination
            int blankFlag = 0;
            dateOfTermination = Regex.Replace(dateOfTermination, @"-+", ""); //removes all whitespace from the inputted date
            
            if (String.Compare("", dateOfTermination) == 0)
            {
                //allowed to be blank... 

                blankFlag = 1;
            }
            else if (!DateTime.TryParseExact(dateOfTermination, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0 && dateOfTermination != "N/A")
            {
                Logger.Log("FullTimeEmployee", "Validate()","Date of Termination is invalid");
                return (false);
            }
            else if(dateOfTermination == "N/A"){
                blankflag = 1;
            }
            
            if(dateOfTermination.Length > 5){
                dateOfTermination = dateOfTermination.Insert(4, "-");
                dateOfTermination = dateOfTermination.Insert(7, "-");
            }
            //validate salary
            if (salary <= 0)
            {
                Logger.Log("FullTimeEmployee", "Validate()","Salary is invalid");
                return (false);
            }
            return (true);
        }

        /** 
        Name: Details()
        Params: None
        Use: The following method is a string builder than builds a string of formatted output stating the value
            of every attribute of the fulltime employee
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

            theDetails += "Salary($): ";
            theDetails += salary;
            theDetails += Environment.NewLine;

            Logger.Log("FullTimeEmployee", "Details()",theDetails); //log the deatils as well
            return (theDetails);
        }

        /**
        Name: ~FulltimeEmployee
        Params: None
        Use: The following is a destructor for the FulltimeEmployee class
        */
        ~FulltimeEmployee()     //destructor for the FullTimeEmployee class
        {
        }


    }
}
