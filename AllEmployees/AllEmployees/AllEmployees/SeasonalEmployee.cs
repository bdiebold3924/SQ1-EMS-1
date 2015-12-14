using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AllEmployees
{
    /**
    Class Name: SeasonalEmployee
    Purpose: The following class is a child of the Employee class and holds all attributes and methods that are specific 
            to the seasonal employee type.
            */
    public class SeasonalEmployee : Employee
    {
        string season; //includes Winter Spring Summer Fall
        double piecePay;
        
        /**
        Name: SeasonalEmployee
        Params: None
        Purpose: The following is a default constructor for the SeasonalEmployee class that sets all
                class attribute values to zero values
                */
        public SeasonalEmployee()   //default constructor
        {
            season = null;
            piecePay = 0.0;

        }
         /**
        Name: SeasonalEmployee
        Params: string _firstName, string _lastName
        Purpose: The following is a constructor for the SeasonalEmployee class that takes the first and last name of the employee
                and sets those values as well as sets all class attribute values to zero values.
                */
        public SeasonalEmployee(string _firstName, string _lastName)
        {
            season = null;
            piecePay = 0.0;

            firstName = String.Copy(_firstName);
            lastName = String.Copy(_lastName);

        }
        /**
        Name: SeasonalEmployee
        Params: string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newSeason, double newPiecePay
        Purpose: The following is a constructor for the SeasonalEmployee class that takes all class attribute values as parameters 
                and sets the class attributes to these specific pass values.
                */
        public SeasonalEmployee(string newFirstName, string newLastName, string newDateOfBirth, string newSIN, string newSeason, double newPiecePay)
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
            else if (String.Compare("fall", newSeason) == 0)
            {
                season = String.Copy(newSeason);
            }
            else
            {
                season = "";
            }
            
            piecePay = newPiecePay;
            employeeType = "SN";
        }

        /**
        Name: SetSeason
        Params: string newSeason
        Use: The following method is a mutator for the season attribute of the SeasonalEmployee class
        */
        public bool SetSeason(string newSeason) //mutator for the season attribute
        {
            string temp = newSeason;
            temp = temp.ToLower();  //set all characters of the string to lower so that case does not matter
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
            else if (String.Compare("", temp) == 0)
            {
                season = String.Copy(temp);
            }
            else
            {
                Logger.Log("SeasonalEmployee", "SetSeason", "Season is invalid, not a real season");
                return (false);
            }
            Logger.Log("SeasonalEmployee", "SetSeason", "Season is valid and set");
            return (true);
        }
        
        
        /**
        Name: SetPiecePay
        Params: string newPay
        Use: The following method is a mutator for the piecePay attribute of the SeasonalEmployee class. Returns false if 
            the value to be set does not adhere to requirements and true if the parameter does and the class attribute was 
            set
            */
        public bool SetPiecePay(string newPay)   //mutator for the seasonal piece pay value 
        {
            if (!double.TryParse(newPay, out piecePay))
            {
                Logger.Log("SeasonalEmployee", "SetPiecePay", "PiecePay is invalid, not a valid number);
                return (false);

            }
            Logger.Log("SeasonalEmployee", "SetPiecePay", "PiecePay is valid, and set");
            return (true);
        }
         /** Details()
            Params: None:
            Use: The following method is a string builder that build a large string of all current attribute values within
                the class. After completion of building this string the method then returns that string to the caller.
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

            theDetails += "Season: ";
            theDetails += season;
            theDetails += Environment.NewLine;

            theDetails += "Piece Pay($): ";
            theDetails += piecePay;
            theDetails += Environment.NewLine;

            Logger.Log("SeasonalEmployee", "Details", theDetails);  //log the details as well
            return (theDetails);
        }
        /**
        Validate()
        Params: None
        Use: This method check all of the attribute values for validity based on requirements of what makes a real contractEmployee.
            if any attribute value is invalid the method will return false. If all pass the requirements the method will return true.
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
                    Logger.Log("SeasonalEmployee", "Validate", "First Name is invalid, contains invalid characters");
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
                    Logger.Log("SeasonalEmployee", "Validate", "Last Name is invalid, contains invalid characters");
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
                Logger.Log("SeasonalEmployee", "Validate", "SIN # is invalid, invalid length");
                return (false);

            }

            //now check that it contains only numbers...


            foreach (char c in socialInsuranceNumber)
            {
                if (c < '0' || c > '9')
                {
                    Logger.Log("SeasonalEmployee", "Validate", "SIN # is invalid, invalid length");
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
                Logger.Log("SeasonalEmployee", "Validate", "SIN # is invalid, does not adhere to SIN # protocol");
                return (false);
            }
            socialInsuranceNumber = socialInsuranceNumber.Insert(3, " ");
            socialInsuranceNumber = socialInsuranceNumber.Insert(7, " ");

            //now check for valid season value..

            if (String.Compare("winter", season) != 0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Season is invalid, not a real season");
                return (false);
            }
            else if (String.Compare("spring", season) != 0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Season is invalid, not a real season");
                return (false);
            }
            else if (String.Compare("summer", season) != 0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Season is invalid, not a real season");
                return (false);
            }
            else if (String.Compare("fall", season) != 0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Season is invalid, not a real season");
                return (false);
            }
            else if (String.Compare("", season) != 0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Season is invalid, not a real season");
                return (false);
            }

            //now validate piece pay
            if (piecePay <= 0.0)
            {
                Logger.Log("SeasonalEmployee", "Validate", "Piece Pay is invalid, must be a number greater than zero.");
                return (false);
            }
            // all attributes validated..
            Logger.Log("SeasonalEmployee", "Validate", "All attributes of the SeasonalEmployee are valid.");
            return (true);
        }

        /**
        Name: ~SeasonalEmployee
        Params: None
        Use: The following is a destructor for the SeasonalEmployee Class
        */
        ~SeasonalEmployee() //destructor for the seasonal employee
        {
        }
    }
}
