/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the ContractEmployee Class<br>
 * PROJECT  :   SQ1 - EMS1<br>
 * 
 */
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
    /** The following class keeps track of all data for the contract employee type 
        and contains all methods for setting and validating this classes attributes.
        */
        
    public class ContractEmployee : Employee
    {
        /**Attributes**/
        public string contractStartDate;
        public string contractStopDate;
        public double fixedContractAmount;

        //SIN for this class holds a Business number... 
        //first name for this class is nothing, last name is the corporations name
        //base date of birth for employees in this class must hold the date of incorporation

        /** ContractEmployee()
            The following method is a default constructor that sets all 
            attributes to 0 values
        */
        public ContractEmployee() : base()
        {
            contractStartDate = null;
            contractStopDate = null;
            fixedContractAmount = 0;

        }
        /**ContractEmployee()
            Parameters: string lastname
            Use: The following method is a constructor that takes the last name, which in this case is a company name
                and sets the remaining attribute value to 0 or null values.
                */
        public ContractEmployee(string _lastName) : base("", _lastName)   //constructor that takes last name.. first name is always blank in this case
        {
            contractStartDate = null;
            contractStopDate = null;
            fixedContractAmount = 0;
        }

        /* ContractEmployee()
            Parameters: string newfirstName, string newlastName, string newDateOfBirth, string newSIN, string new contractStartDate, string newContractStopDate, int newFixedContractAmount)
            Use: The following method is a constructor that takes parameters for all attributes and assigns these values to the 
                class attributes.
                */
        public ContractEmployee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN,
            string newContractStartDate, string newContractStopDate, double newFixedContractAmount)
            : base(newFirstName, newLastName, newDateOfBirth, newSIN)
        {
            contractStartDate = String.Copy(newContractStartDate);
            contractStopDate = String.Copy(newContractStopDate);
            fixedContractAmount = newFixedContractAmount;
            employeeType = "CT";
        }
        /**~ContractEmployee()
            Params: None
            Use: The following method is a destructor for the contractEmployee class
            */
        ~ContractEmployee()     //destructor for the contract employee class
        {
        }

        /** SetFixedContractAmount()
        Params: string newAmount
        Use: The following method is used to take in a new fixed contract amount value for the 
            fixedContractAmount attribute in the class. After checking that the inputted value is 
            valid based on the requirements of the project, the method will either set or not set the 
            attribute and log feedback of what happened as well as return true or false if the inputted 
            value was valid or not.
            */
        public bool SetFixedContractAmount(string newAmount)
        {
            if (!double.TryParse(newAmount, out fixedContractAmount))  //check to see if the inputted string is an int and if it is not..
            {
               
                Logger.Log("ContractEmployee", "SetFixedContractAmount", "New amount entered is invalid, not an integer."); 
                return (false);

            }
            
             int newNum = Int32.Parse(newAmount);
            if (newNum < 0)
            {
               Logger.Log("ContractEmployee", "SetFixedContractAmount", "New amount entered is invalid, not an integer.");
                return (false);
            }
            fixedContractAmount = newNum;
             Logger.Log("ContractEmployee", "SetFixedContractAmount", "New contract amount entered is valid");
            return (true);
        }
        
        /** Details()
            Params: None:
            Use: The following method is a string builder that build a large string of all current attribute values within
                the class. After completion of building this string the method then returns that string to the caller.
                */
        public string Details()
        {

            // string builder that builds the full output details of every attribute of the current employee object


            string theDetails = "Employee Details:\n";      //set starting point for the string

            theDetails = String.Concat(theDetails, "Company Name: ");   //append company name
            theDetails = String.Concat(theDetails, lastName);           //append the last name attribute

            theDetails += Environment.NewLine;  //append a new line

            //remaining lines all follow this appending order
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
       
        /** SetContractStartDate()
            Params: string newStartDate
            Use: The following method takes in a string that is date and will check to see if it is a valid date,
                if it is it will set the contractStartDate attribute in the class to this and log the change, if not
                the method will return false and log the issue with the entered value
                */
        public bool SetContractStartDate(string newStartDate)
        {
            string temp = newStartDate; 
            DateTime result;    //used as an output value when checking to see if the date is valid

            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            
            if(temp.Equals("N/A")){
                 Logger.Log("ContractEmployee", "SetContractStartDate", "Contract start date is valid and set.");
                 contractStartDate = String.Copy(temp);
                 return (true);
            }
            if(temp.Equals("")){
                 Logger.Log("ContractEmployee", "SetContractStartDate", "Contract start date is valid and set.");
                 contractStartDate = String.Copy(temp);
                 return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Logger.Log("ContractEmployee", "SetContractStartDate", "Date entered is not a real date");
                return (false);
            }
            //since the date was verified...
            contractStartDate = String.Copy(temp);  //set the contract start date to the inputted value

            contractStartDate = contractStartDate.Insert(4, "-");   //now append the dashes for formatting output in the requirements
            contractStartDate = contractStartDate.Insert(7, "-");
            
             Logger.Log("ContractEmployee", "SetContractStartDate", "Date entered is valid. contractStartDate was updated.");   //log the change 
            return true;
        }
        
         /** SetContractStopDate()
            Params: string newStopDate
            Use: The following method takes in a string that is date and will check to see if it is a valid date,
                if it is it will set the contractStopDate attribute in the class to this and log the change, if not
                the method will return false and log the issue with the entered value
                */
        public bool SetContractStopDate(string newStopDate)
        {
            string temp = newStopDate;
            DateTime result;    //output value needed for the date validity check

            temp = Regex.Replace(temp, @"-+", ""); //removes all whitespace from the inputted date
            
            if(temp.Equals("N/A")){
                 Logger.Log("ContractEmployee", "SetContractStopDate", "Contract stop date is valid and set.");
                 contractStopDate = String.Copy(temp);
                 return (true);
            }
            if (String.Compare("", temp) == 0)  //check to see if the date is an blank string
            {
                //allowed to be blank... update the value
                contractStopDate = String.Copy(temp);
                Logger.Log("ContractEmployee", "SetContractStopDate", "Date entered is valid. contractStopDate was updated.");   //log the change 
                return (true);
            }
            if (!DateTime.TryParseExact(temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))    //if not a real date..
            {
                Logger.Log("ContractEmployee", "SetContractStoptDate", "Date entered is invalid. Not a real date.");   //log the change 
                return (false);
            }
            //since date was valid
            contractStopDate = String.Copy(temp);   //update the variable

            contractStopDate = contractStopDate.Insert(4, "-"); //format the string for output purposes
            contractStopDate = contractStopDate.Insert(7, "-");
            
            Logger.Log("ContractEmployee", "SetContractStopDate", "Date entered is valid. contractStopDate was updated.");   //log the change 
            return true;
        }

        /**
        Validate()
        Params: None
        Use: This method check all of the attribute values for validity based on requirements of what makes a real contractEmployee.
            if any attribute value is invalid the method will return false. If all pass the requirements the method will return true.
            */
        public bool Validate()
        {
            //do not have to check first name for validity because the first name in this method is going to be blank.
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
                    Logger.Log("ContractEmployee", "Validate", "Company Name is invalid");   //log the change 
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


            if ((socialInsuranceNumber.Length == 0) || (socialInsuranceNumber.Length < 9) || (socialInsuranceNumber.Length > 9))    //if the size of the SIN is exceeded or too small it is invalid
            {
                Logger.Log("ContractEmployee", "Validate", "B/N is invalid");   //log the change 
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9') //if the SIN contains anything other than numbers it is invalid
                {
                    Logger.Log("ContractEmployee", "Validate", "B/N is invalid");   //log the change 
                    return (false);
                }
            }

            //now can do SIN manipulation...

            for (intCount = 1; intCount <= 8; intCount++)
            {
                if (intCount % 2 == 0)    //if the intCount is an even number
                {
                    temp1 = (int)Char.GetNumericValue(socialInsuranceNumber[intCount - 1]); //you use the first 8 numbers of the SIN
                    temp1 = temp1 * 2;  //all even numbers get multiplied by two
                    if (temp1 > 9)  //if they are over 10 when x2 then you add as two numbers. Ex. if product was 12 you would add a 1+2 not +12
                    {
                        intEven = intEven + 1 + (temp1 - 10);   //add the 1 and the carry over number as separate numbers to the even number sum
                    }
                    else
                    {
                        intEven = intEven + temp1;  //if it's below 10 just add the number to the even sum
                    }
                }
                if (intCount % 2 != 0)  
                {
                    intOdd = intOdd + (int)Char.GetNumericValue(socialInsuranceNumber[intCount - 1]);   //odd numbers just get added 
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

                 Logger.Log("ContractEmployee", "Validate", "B/N # is invalid");   //log the change 
                return (false);
            }
            if ((int)Char.GetNumericValue(socialInsuranceNumber[0]) != (int)Char.GetNumericValue(dateOfBirth[2]))//for contractEmployee the last two numbers of Date of birth must be the first two numbers of the SIN
            {
                 Logger.Log("ContractEmployee", "Validate", "B/N is invalid");   //log the change 
                return (false);
            }
            if ((int)Char.GetNumericValue(socialInsuranceNumber[1]) != (int)Char.GetNumericValue(dateOfBirth[3]))
            {
                Logger.Log("ContractEmployee", "Validate", "B/N is invalid");   //log the change 
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(5, " ");   //formats the output accordingly


            //now validate Date of birth... stands for date of incorporation
            //follows the same date checking algorithm as mutators
            DateTime result;

            dateOfBirth = Regex.Replace(dateOfBirth, @"-+", ""); //removes all whitespace from the inputted date

           
            if(dateOfBirth != "N/A"){
                if (!DateTime.TryParseExact(dateOfBirth, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                {
                    Logger.Log("ContractEmployee", "Validate", "date of birth is invalid");   //log the change 
                    return (false);
                }
            }
        
            if(dateOfBirth.Length > 3)
            {
                dateOfBirth = dateOfBirth.Insert(4, "-");
                dateOfBirth = dateOfBirth.Insert(7, "-");  //reformat the string for output purposes 
            }
            //now validate contract start date
            //follows same date checking algorithm as setContractStartDate
            contractStartDate = Regex.Replace(contractStartDate, @"-+", ""); //removes all whitespace from the inputted date

            if(contractStartDate != "N/A"){
                if (!DateTime.TryParseExact(contractStartDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
                {
                    Logger.Log("ContractEmployee", "Validate", "Contract start date is invalid");   //log the change 
                    return (false);
                }
            }

            if(contractStartDate.Length > 3)
            {
                contractStartDate = contractStartDate.Insert(4, "-");
                contractStartDate = contractStartDate.Insert(7, "-");
            }
            

            //now validate date of termination
            int blankFlag = 0;
            contractStopDate = Regex.Replace(contractStopDate, @"-+", ""); //removes all whitespace from the inputted date
    
            if(contractStopDate != "N/A"){
                if (!DateTime.TryParseExact(contractStopDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) && blankFlag == 0)
                {
                    Logger.Log("ContractEmployee", "Validate", "Contract Stop date is invalid");   //log the change 
                    return (false);
                }
            }
            if(contractStopDate.Length > 3){
                contractStopDate = contractStopDate.Insert(4, "-");
                contractStopDate = contractStopDate.Insert(7, "-");
            }
            //validate salary
            if (fixedContractAmount <= 0)   //cannot be less than or equal to zero
            {
                Logger.Log("ContractEmployee", "Validate", "Salary is invalid");   //log the change 
                return (false);
            }
            Logger.Log("ContractEmployee", "Validate", "All Attributes for ContractEmployee are valid");   //log the change 
            return (true);
        }


    }
}
