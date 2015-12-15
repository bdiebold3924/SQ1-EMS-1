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

        public void Add(Employee newEmployee, bool valid)
        {
            if (valid)
            {
                theCompany.Add(newEmployee);
                Logger.Log("TheCompany", "Add", "New employee was officially added to TheCompany");
            }
        }

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

        public void Modify()   //allows for modification to the whichever current object is being looked at and wants to be modified.
        {
            //! Do to a design decision made by the Project Manager Brandon Diebold,
            //! the logic for this method was added to Presentation.UIMenu.employeeDetailsMenu(string employeeSIN).
        }
        ~Company()   //destructor for the company 
        {
        }
    }
}
