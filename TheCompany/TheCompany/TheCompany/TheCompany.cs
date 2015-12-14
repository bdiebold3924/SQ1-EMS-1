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
            foreach (Employee e in theCompany)
            {
                if(e.socialInsuranceNumber == SIN)
                {
                    theCompany.Remove(e);     //removes the current employee being looked at from the container
                     Logger.Log("TheCompany", "Remove", "Current employee being looked at was removed from TheCompany");
                }
            }
        }

        public string Traverse() //allows for traversal through the company container 
        {
            string retStr = "";
            foreach (FulltimeEmployee e in theCompany)
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (ParttimeEmployee e in theCompany)
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (SeasonalEmployee e in theCompany)
            {
                retStr += e.Details();
                retStr += "\n";
            }
            foreach (ContractEmployee e in theCompany)
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
            foreach (FulltimeEmployee e in theCompany)
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (ParttimeEmployee e in theCompany)
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (SeasonalEmployee e in theCompany)
            {
                if (e.socialInsuranceNumber == SIN)
                {
                    retStr = e.Details();
                }
            }
            foreach (ContractEmployee e in theCompany)
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

        }
        ~Company()   //destructor for the company 
        {
        }
    }
}
