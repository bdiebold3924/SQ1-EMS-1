using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AllEmployees;


namespace TheCompany
{
    public class Company
    {
        List<Employee> theCompany = new List<Employee>();

        public string firstName;
        public string lastName;
        public string dateOfBirth;
        public string socialInsuranceNumber;


        int current = 0, next = 0, last = 0;


        public Company()    //constructor that sets the company container to be empty.
        {

        }

        public void Add(Employee newEmployee, bool valid)
        {
            if (valid)
            {
                theCompany.Add(newEmployee);
            }
        }

        public void Remove(string SIN)
        {
            foreach (Employee e in theCompany)
            {
                if(e.socialInsuranceNumber == SIN)
                {
                    theCompany.Remove(e);     //removes the current employee being looked at from the container
                }
            }
        }

        public string Traverse() //allows for traversal through the company container 
        {
            string retStr = "";
            foreach (FulltimeEmployee e in theCompany)
            {
                retStr += e.Details();
            }
            foreach (ParttimeEmployee e in theCompany)
            {
                retStr += e.Details();
            }
            foreach (SeasonalEmployee e in theCompany)
            {
                retStr += e.Details();
            }
            foreach (ContractEmployee e in theCompany)
            {
                retStr += e.Details();
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

        public void Modify()   //allows for modification to the whichever current object is being looked at and wants to be modified.
        {

        }
        ~Company()   //destructor for the company 
        {
            Console.WriteLine("Company list cleaned and destroyed.");
        }


    }

}
