using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace TheCompany
{
    public class TheCompany
    {
        List<object> theCompany = new List<object>();

        public string firstName;
        public string lastName;
        public string dateOfBirth;
        public string socialInsuranceNumber;


        int current = 0, next = 0, last = 0;


        TheCompany()    //constructor that sets the company container to be empty.
        {
            theCompany = null;

        }

        void Add(Object newEmployee)    //can only be called if the current employee object is validated...
        {

            theCompany.Add(newEmployee);
            
        }

        void Remove(Object newEmployee)
        {
            theCompany.Remove(newEmployee);     //removes the current employee being looked at from the container
        }

        public string Traverse() //allows for traversal through the company container 
        {







            return "";

        }

        void Modify()   //allows for modification to the whichever current object is being looked at and wants to be modified.
        {

        }
        ~TheCompany()   //destructor for the company 
        {
            Console.WriteLine("Company list cleaned and destroyed.");
        }


    }

}
