/*! \mainpage Main Page
 * 
 * \section intro_sec Introduction
 * 
 * Technical Specification for the Company Class<br>
 * PROJECT  :   SQ1 - EMS1<br>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AllEmployees;
using Supporting;

namespace TheCompany
{
    /*!
    * NAME     : Company<br>
    * PURPOSE  : The Company class is the container for the program and holds the list of Employees.
    *               It contains methods for Adding, Removing, and Traversing the list.
    */
    public class Company
    {
        List<Employee> theCompany = new List<Employee>();

        public string firstName;
        public string lastName;
        public string dateOfBirth;
        public string socialInsuranceNumber;


        public Company()    //constructor that sets the company container to be empty.
        {

        }

        /*!
         * FUNCTION     : public void Add(Employee newEmployee, bool valid)
         * 
         * DESCRIPTION  : This method is used to add newEmployee to the list only if valid is true.
         * 
         * PARAMETERS   : \param Employee newEmployee   : the employee to add.
         *                \param bool valid             : whether or not newEmployee is valid
         * 
         * RETURN       : None
         * 
         */
        public void Add(Employee newEmployee, bool valid)
        {
            if (valid)
            {
                theCompany.Add(newEmployee);
                Logger.Log("TheCompany", "Add", "New employee was officially added to TheCompany");
            }
        }

        /*!
         * FUNCTION     : public void Remove(string SIN)
         * 
         * DESCRIPTION  : This method is used to remove an Employee from the list.
         *                  The Employee is found through the SIN as that is almost garanteed to be unique.
         * 
         * PARAMETERS   : \param string SIN : the social insurance number of the Employee to remove
         * 
         * RETURN       : None
         * 
         */
        public void Remove(string SIN)
        {
            for (int x = 0; x < theCompany.Count(); x++ )
            {
                if (theCompany[x].socialInsuranceNumber == SIN)
                {
                    theCompany.Remove(theCompany[x]);     //removes the current employee being looked at from the container
                    Logger.Log("TheCompany", "Remove", "Current employee being looked at was removed from TheCompany");
                }
            }
        }

        /*!
         * FUNCTION     : public string GetDetailsToSave()
         * 
         * DESCRIPTION  : This method gets the details of each employee and puts them into a string that is in the correct format.
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : string    : the string of details to be saved
         * 
         */
        public string GetDetailsToSave()
        {
            string retStr = "";
            foreach (FulltimeEmployee e in theCompany.OfType<FulltimeEmployee>())
            {
                retStr += e.employeeType;
                retStr += "|";
                retStr += e.lastName;
                retStr += "|";
                retStr += e.firstName;
                retStr += "|";
                retStr += e.socialInsuranceNumber;
                retStr += "|";
                retStr += e.dateOfBirth;
                retStr += "|";
                retStr += e.dateOfHire;
                retStr += "|";
                retStr += e.dateOfTermination;
                retStr += "|";
                retStr += e.salary;
                retStr += "|";
                retStr += "\n";
            }
            foreach (ParttimeEmployee e in theCompany.OfType<ParttimeEmployee>())
            {
                retStr += e.employeeType;
                retStr += "|";
                retStr += e.lastName;
                retStr += "|";
                retStr += e.firstName;
                retStr += "|";
                retStr += e.socialInsuranceNumber;
                retStr += "|";
                retStr += e.dateOfBirth;
                retStr += "|";
                retStr += e.dateOfHire;
                retStr += "|";
                retStr += e.dateOfTermination;
                retStr += "|";
                retStr += e.hourlyRate;
                retStr += "|";
                retStr += "\n";
            }
            foreach (SeasonalEmployee e in theCompany.OfType<SeasonalEmployee>())
            {
                retStr += e.employeeType;
                retStr += "|";
                retStr += e.lastName;
                retStr += "|";
                retStr += e.firstName;
                retStr += "|";
                retStr += e.socialInsuranceNumber;
                retStr += "|";
                retStr += e.dateOfBirth;
                retStr += "|";
                retStr += e.season;
                retStr += "|";
                retStr += e.piecePay;
                retStr += "|";
                retStr += "\n";
            }
            foreach (ContractEmployee e in theCompany.OfType<ContractEmployee>())
            {
                retStr += e.employeeType;
                retStr += "|";
                retStr += e.lastName;
                retStr += "|";
                retStr += e.firstName;
                retStr += "|";
                retStr += e.socialInsuranceNumber;
                retStr += "|";
                retStr += e.dateOfBirth;
                retStr += "|";
                retStr += e.contractStartDate;
                retStr += "|";
                retStr += e.contractStopDate;
                retStr += "|";
                retStr += e.fixedContractAmount;
                retStr += "|";
                retStr += "\n";
            }
            return retStr;
        }

        /*!
         * FUNCTION     : public string Traverse()
         * 
         * DESCRIPTION  : This method gets the 
         * 
         * PARAMETERS   : 
         * 
         * RETURN       : string    : the formated string of employees details
         * 
         */
        public string Traverse() //allows for traversal through the company container 
        {
            string retStr = "";
            foreach (FulltimeEmployee e in theCompany.OfType<FulltimeEmployee>())
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (ParttimeEmployee e in theCompany.OfType<ParttimeEmployee>())
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (SeasonalEmployee e in theCompany.OfType<SeasonalEmployee>())
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (ContractEmployee e in theCompany.OfType<ContractEmployee>())
            {
                retStr += e.Details();
                retStr += "\n";
            }
            if (retStr == "")
            {
                retStr = "There are no employees in the database.";
            }
            return retStr;
        }

        /*!
         * FUNCTION     : public string Traverse(string SIN)
         * 
         * DESCRIPTION  : This method gets the details of the Employee with a matching SIN.
         * 
         * PARAMETERS   : \param string SIN : the social insurance number of the Employee to find
         * 
         * RETURN       : string    : the formated string of employees details
         * 
         */
        public string Traverse(string SIN) //allows for traversal through the company container 
        {
            string retStr = "";
            foreach (FulltimeEmployee e in theCompany.OfType<FulltimeEmployee>())
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (ParttimeEmployee e in theCompany.OfType<ParttimeEmployee>())
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (SeasonalEmployee e in theCompany.OfType<SeasonalEmployee>())
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (ContractEmployee e in theCompany.OfType<ContractEmployee>())
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            return retStr;
        }

        /*!
         * FUNCTION     : public void Traverse(string SIN, ref Employee tempEmp)
         * 
         * DESCRIPTION  : This method gets the details of the Employee with a matching SIN and puts it in tempEmp.
         * 
         * PARAMETERS   : \param string SIN             : the social insurance number of the Employee to find
         *              : \param ref Employee tempEmp   : the Employee details
         * 
         * RETURN       : None
         * 
         */
        public void Traverse(string SIN, ref Employee tempEmp) //allows for traversal through the company container 
        {
            foreach (Employee e in theCompany)
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    tempEmp = e;
                }
            }
        }

        /*!
         * FUNCTION     : public void Modify()
         * 
         * DESCRIPTION  : Do to a design decision made by the Project Manager Brandon Diebold,
         *                  the logic for this method was added to Presentation.UIMenu.employeeDetailsMenu(string employeeSIN).
         * 
         * PARAMETERS   : None
         * 
         * RETURN       : None
         * 
         */
        public void Modify()   //allows for modification to the whichever current object is being looked at and wants to be modified.
        {
        }
        ~Company()   //destructor for the company 
        {
        }
    }
}
