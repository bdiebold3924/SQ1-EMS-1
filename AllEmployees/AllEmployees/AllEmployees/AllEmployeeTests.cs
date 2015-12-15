using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;


namespace AllEmployeesTest
{
    [TestClass]
    public class AllEmployeesTests
    {

        /**
* \brief Method that runs the test for setting a first name
* \details <b>Details</b>
* -Follows the happy path through the code for normal functionality.<br>
-If the test fails first name will not be set and method would return false"<br>
* -Expected outcome: SetFirstName method should return true
Result: Method returned true, firstName was set.
*/
        [TestMethod]
        public void testSetFirstName1()
        {
            var employee = new Employee();
            bool check = employee.SetFirstName("Bill");

            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a first name
* \details <b>Details</b>
* -Checks to see that the method does not allow numbers or invalid names <br>
-If the test fails first name will be set and method would return true"<br>
* -Expected outcome: SetFirstName method should return false
* Result: Method returned false, firstName was not set.
*/
        [TestMethod]
        public void testSetFirstName2()
        {
            var employee = new Employee();
            bool check = employee.SetFirstName("Ke9it ");

            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a first name
* \details <b>Details</b>
* -Checks to see that the method allows for special character such as an apostrophe in a name.<br>
-If the test fails first name will not be set and method would return false"<br>
* -Expected outcome: SetFirstName method should return true
Result: Method returned true, firstName was set.
*/
        [TestMethod]
        public void testSetFirstName3()
        {
            var employee = new Employee();
            bool check = employee.SetFirstName("Mary'Anne");

            Assert.AreEqual(true, check);
        }



        /**
* \brief Method that runs the test for setting a last name
* \details <b>Details</b>
* -Follows the happy path through the code for normal functionality.<br>
-If the test fails last name will not be set and method would return false"<br>
* -Expected outcome: SetLastName method should return true
Result: Method returned true, lastName was set.
*/
        [TestMethod]
        public void testSetLastName1()
        {
            var employee = new Employee();
            bool check = employee.SetLastName("James-Rire's");

            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a last name
* \details <b>Details</b>
* -Checks to see that illegal characters are not allowed in the name<br>
-If the test fails last name will be set and method would return true"<br>
* -Expected outcome: SetLastName method should return false
Result: Method returned false, lastName was not set.
*/
        [TestMethod]
        public void testSetLastName2()
        {
            var employee = new Employee();
            bool check = employee.SetLastName("Jamis98n");

            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a last name
* \details <b>Details</b>
* -Checks to see that special characters are allowed in the last name<br>
-If the test fails last name will not be set and method would return false"<br>
* -Expected outcome: SetLastName method should return true
Result: Method returned true, lastName was set.
*/
        [TestMethod]
        public void testSetLastName3()
        {
            var employee = new Employee();
            bool check = employee.SetLastName("James-May're");

            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of birth
* \details <b>Details</b>
* -Follows the happy path through the code for normal functionality.<br>
-If the test fails date of birth will not be set and method would return false"<br>
* -Expected outcome: DateOfBirth method should return true
Result: Method returned true, dateOfBirth was set.
*/
        [TestMethod]
        public void testSetDateOfBirth1()
        {
            var employee = new Employee();
            bool check = employee.SetDateOfBirth("19930419");       //yyyyMMdd format


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of birth
* \details <b>Details</b>
* -Checks that none real dates cannot be used as valid input.<br>
-If the test fails date of birth will be set and method would return true"<br>
* -Expected outcome: DateOfBirth method should return false
Result: Method returned false, dateOfBirth was not set.
*/
        [TestMethod]
        public void testSetDateOfBirth2()
        {
            var employee = new Employee();
            bool check = employee.SetDateOfBirth("20011345");       //yyyyMMdd format


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a date of birth
* \details <b>Details</b>
* -Checks that leap years are indeed taken as valid input.<br>
-If the test fails date of birth will not be set and method would return false"<br>
* -Expected outcome: DateOfBirth method should return true
Result: Method returned true, dateOfBirth was set.
*/
        [TestMethod]
        public void testSetDateOfBirth3()
        {
            var employee = new Employee();
            bool check = employee.SetDateOfBirth("20080229");       //yyyyMMdd format.. feb 29th 2008 was a leap year date


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of birth
* \details <b>Details</b>
* -Checks that invalid characters cannot be used for dates <br>
-If the test fails date of birth will be set and method would return true"<br>
* -Expected outcome: DateOfBirth method should return false
Result: Method returned false, dateOfBirth was not set.
*/
        [TestMethod]
        public void testSetDateOfBirth4()
        {
            var employee = new Employee();
            bool check = employee.SetDateOfBirth("2008Feb29");      


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a SIN number
* \details <b>Details</b>
* -Happy Path check to see if accepts a valid SIN number <br>
-If the test fails date of SIN will not be set and method would return false"<br>
* -Expected outcome: SetSIN method should return true
Result: Method returned true, socialInsuranceNumber was set
*/
        [TestMethod]
        public void testSetSIN1()
        {
            var employee = new Employee();
            bool check = employee.SetSIN("194973343");  //is a valid SIN


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a SIN number
* \details <b>Details</b>
* -Check to see does not accept invalid SIN number <br>
-If the test fails date of SIN will be set and method would return true"<br>
* -Expected outcome: SetSIN method should return false
Result: Method returned false, socialInsuranceNumber was not set
*/
        [TestMethod]
        public void testSetSIN2()
        {
            var employee = new Employee();
            bool check = employee.SetSIN("192973343");  //invalid SIN


            Assert.AreEqual(false, check);
        }


        /**
* \brief Method that runs the test for setting a SIN number
* \details <b>Details</b>
* -bounds check to see that only a 9 digit number is accepted <br>
-If the test fails date of SIN will be set and method would return true"<br>
* -Expected outcome: SetSIN method should return false
Result: Method returned false, socialInsuranceNumber was not set
*/
        [TestMethod]
        public void testSetSIN3()
        {
            var employee = new Employee();
            bool check = employee.SetSIN("1949733435");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a SIN number
* \details <b>Details</b>
* -bounds check to see that only a 9 digit number is accepted <br>
-If the test fails date of SIN will be set and method would return true"<br>
* -Expected outcome: SetSIN method should return false
Result: Method returned false, socialInsuranceNumber was not set
*/
        [TestMethod]
        public void testSetSIN4()
        {
            var employee = new Employee();
            bool check = employee.SetSIN("194973");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a SIN number
* \details <b>Details</b>
* -check to see that non number characters are not accepted <br>
-If the test fails date of SIN will be set and method would return true"<br>
* -Expected outcome: SetSIN method should return false
Result: Method returned false, socialInsuranceNumber was not set
*/
        [TestMethod]
        public void testSetSIN5()
        {
            var employee = new Employee();
            bool check = employee.SetSIN("194973BA4");


            Assert.AreEqual(false, check);
        }



        /**
* \brief Method that runs the test for setting a fixed contract amount for Contract Employees
* \details <b>Details</b>
* -happy path to see that it takes the appropriate value and sets it<br>
-If the test fails date of contract amount will not be set and method would return false"<br>
* -Expected outcome: SetFixedContractAmount method should return true
Result: Method returned true, fixedContractAmount was set.
*/
        [TestMethod]
        public void testSetFixedContractAmount1()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetFixedContractAmount("20000");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a fixed contract amount for Contract Employees
* \details <b>Details</b>
* - Bounds Check to see if accepts invalid lower than zero contract amount <br>
-If the test fails date of contract amount will be set and method would return true"<br>
* -Expected outcome: SetFixedContractAmount method should return false
Result: Method returned false, fixedContractAmount was not set.
*/
        [TestMethod]
        public void testSetFixedContractAmount2()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetFixedContractAmount("-1000");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a fixed contract amount for Contract Employees
* \details <b>Details</b>
* - Bounds Check to see if accepts 0 <br>
-If the test fails date of contract amount will not be set and method would return false"<br>
* -Expected outcome: SetFixedContractAmount method should return true
Result: Method returned true, fixedContractAmount was set.
*/
        [TestMethod]
        public void testSetFixedContractAmount3()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetFixedContractAmount("0");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a fixed contract amount for Contract Employees
* \details <b>Details</b>
* - Exception check to see that letters are not accepted as input <br>
-If the test fails date of contract amount will be set and method would return true"<br>
* -Expected outcome: SetFixedContractAmount method should return false
Result: Method returned false, fixedContractAmount was not set.
*/
        [TestMethod]
        public void testSetFixedContractAmount4()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetFixedContractAmount("2054B3");


            Assert.AreEqual(false, check);
        }
    

    /**
* \brief Method that runs the test for setting a contract start date for contract employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails contract start date will not be set and method would return false"<br>
* -Expected outcome: SetContractStartDate method should return true
Result: Method returned true, contractStartDate was set.
*/
        [TestMethod]
        public void testSetContractStartDate1()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStartDate("20000419");       


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a contract start date for contract employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails contract start date will not be set and method would return false"<br>
* -Expected outcome: SetContractStartDate method should return true
Result: Method returned true, contractStartDate was set.
*/
        [TestMethod]
        public void testSetContractStartDate2()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStartDate("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a contract start date for contract employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails contract start date will be set and method would return true"<br>
* -Expected outcome: SetContractStartDate method should return false
Result: Method returned false, contractStartDate was not set.
*/
        [TestMethod]
        public void testSetContractStartDate3()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStartDate("2000B423");


            Assert.AreEqual(false, check);
        }


        /**
* \brief Method that runs the test for setting a contract stop date for contract employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails contract stop date will not be set and method would return false"<br>
* -Expected outcome: SetContractStopDate method should return true
Result: Method returned true, contractStopDate was set.
*/
        [TestMethod]
        public void testSetContractStopDate1()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStopDate("20000419");


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a contract stop date for contract employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails contract stop date will not be set and method would return false"<br>
* -Expected outcome: SetContractStopDate method should return true
Result: Method returned true, contractStopDate was set.
*/
        [TestMethod]
        public void testSetContractStopDate2()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStopDate("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a contract stop date for contract employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails contract stop date will be set and method would return true"<br>
* -Expected outcome: SetContractStopDate method should return false
Result: Method returned false, contractStopDate was not set.
*/
        [TestMethod]
        public void testSetContractStopDate3()
        {
            var employee = new ContractEmployee();
            bool check = employee.SetContractStopDate("2000B423");


            Assert.AreEqual(false, check);
        }



        //start of fulltime employee testing

        /**
* \brief Method that runs the test for setting a salary for full time employees
* \details <b>Details</b>
* -Happy path to see that salary inputted is valid<br>
-If the test fails salary will be set and method would return false"<br>
* -Expected outcome: SetSalary method should return true
Result: Method returned true, salary was set.
*/
        [TestMethod]
        public void testSetSalary1()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetSalary("2000");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a salary for full time employees
* \details <b>Details</b>
* -Check that lower than 0 values are not accepted<br>
-If the test fails salary will be set and method would return true"<br>
* -Expected outcome: SetSalary method should return false
Result: Method returned false, salary was not set.
*/
        [TestMethod]
        public void testSetSalary2()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetSalary("-2000");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a salary for full time employees
* \details <b>Details</b>
* -Check to see that 0 is consideered valid<br>
-If the test fails salary will be not set and method would return false"<br>
* -Expected outcome: SetSalary method should return true
Result: Method returned true, salary was set.
*/
        [TestMethod]
        public void testSetSalary3()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetSalary("0");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a salary for full time employees
* \details <b>Details</b>
* -Check that non valid characters are not allowed by the method<br>
-If the test fails salary will be set and method would return true"<br>
* -Expected outcome: SetSalary method should return false
Result: Method returned false, salary was not set.
*/
        [TestMethod]
        public void testSetSalary4()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetSalary("345B4");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a date of hire for full time employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails date of hire will not be set and method would return false"<br>
* -Expected outcome: SetDateOfHire method should return true
Result: Method returned true, dateOfHire was set.
*/
        [TestMethod]
        public void testDateOfHire1()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfHire("20000419");


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a date of hire for fulltime employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails date of hire will not be set and method would return false"<br>
* -Expected outcome: SetDateOfHire method should return true
Result: Method returned true, dateOfHire was set.
*/
        [TestMethod]
        public void testSetDateOfHire2()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfHire("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of hire for fulltime employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails date of hire will be set and method would return true"<br>
* -Expected outcome: SetDateOfHire method should return false
Result: Method returned false, dateOfHire was not set.
*/
        [TestMethod]
        public void testSetDateOfHire3()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfHire("2000B423");


            Assert.AreEqual(false, check);
        }



        /**
* \brief Method that runs the test for setting a date of hire for full time employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails date of termination will not be set and method would return false"<br>
* -Expected outcome: SetDateOfTermination method should return true
Result: Method returned true, dateOfTermination was set.
*/
        [TestMethod]
        public void testDateOfTermination1()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfTermination("20000419");


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a date of termination for fulltime employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails date of termination will not be set and method would return false"<br>
* -Expected outcome: SetDateOfTermination method should return true
Result: Method returned true, dateOfTermination was set.
*/
        [TestMethod]
        public void testSetDateOfTermination2()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfTermination("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of termination for fulltime employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails date of termination will be set and method would return true"<br>
* -Expected outcome: SetDateOfTermination method should return false
Result: Method returned false, dateOfTermination was not set.
*/
        [TestMethod]
        public void testSetDateOfTermination3()
        {
            var employee = new FulltimeEmployee();
            bool check = employee.SetDateOfTermination("2000B423");


            Assert.AreEqual(false, check);
        }



        //part time employee tests

        /**
* \brief Method that runs the test for setting a date of hire for part time employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails date of hire will not be set and method would return false"<br>
* -Expected outcome: SetDateOfHire method should return true
Result: Method returned true, dateOfHire was set.
*/
        [TestMethod]
        public void testDateOfHirePT1()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfHire("20000419");


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a date of hire for part time employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails date of hire will not be set and method would return false"<br>
* -Expected outcome: SetDateOfHire method should return true
Result: Method returned true, dateOfHire was set.
*/
        [TestMethod]
        public void testSetDateOfHirePT2()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfHire("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of hire for part time employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails date of hire will be set and method would return true"<br>
* -Expected outcome: SetDateOfHire method should return false
Result: Method returned false, dateOfHire was not set.
*/
        [TestMethod]
        public void testSetDateOfHirePT3()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfHire("2000B423");


            Assert.AreEqual(false, check);
        }



        /**
* \brief Method that runs the test for setting a date of hire for full part time employees
* \details <b>Details</b>
* -happy path to see valid years are indeed taken as valid input.<br>
-If the test fails date of termination will not be set and method would return false"<br>
* -Expected outcome: SetDateOfTermination method should return true
Result: Method returned true, dateOfTermination was set.
*/
        [TestMethod]
        public void testDateOfTerminationPT1()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfTermination("20000419");


            Assert.AreEqual(true, check);
        }


        /**
* \brief Method that runs the test for setting a date of termination for part time employees
* \details <b>Details</b>
* -check to see if leap years are taken as valid.<br>
-If the test fails date of termination will not be set and method would return false"<br>
* -Expected outcome: SetDateOfTermination method should return true
Result: Method returned true, dateOfTermination was set.
*/
        [TestMethod]
        public void testSetDateOfTerminationPT2()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfTermination("20080229");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a date of termination for part time employees
* \details <b>Details</b>
* -Check to see that invalid characters aren't accepted<br>
-If the test fails date of termination will be set and method would return true"<br>
* -Expected outcome: SetDateOfTermination method should return false
Result: Method returned false, dateOfTermination was not set.
*/
        [TestMethod]
        public void testSetDateOfTerminationPT3()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetDateOfTermination("2000B423");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a the hourly rate for part time employees
* \details <b>Details</b>
* -Check to see that valid doubles are allowed <br>
-If the test fails hourly rate will not be set and method would return false"<br>
* -Expected outcome: SetHourlyRate method should return true
Result: Method returned true, hourlyRate was set.
*/
        [TestMethod]
        public void testSetHourlyRate1()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetHourlyRate("12.23");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a the hourly rate for part time employees
* \details <b>Details</b>
* -Check to see that 0 is allowed <br>
-If the test fails hourly rate will not be set and method would return false"<br>
* -Expected outcome: SetHourlyRate method should return true
Result: Method returned true, hourlyRate was set.
*/
        [TestMethod]
        public void testSetHourlyRate2()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetHourlyRate("0.0");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting a the hourly rate for part time employees
* \details <b>Details</b>
* -Bounds Check to see that negative numbers are not allowed<br>
-If the test fails hourly rate will be set and method would return true"<br>
* -Expected outcome: SetHourlyRate method should return false
Result: Method returned false, hourlyRate was not set.
*/
        [TestMethod]
        public void testSetHourlyRate3()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetHourlyRate("-12.23");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting a the hourly rate for part time employees
* \details <b>Details</b>
* -Exception Check to see that invalid chars are not allowed  <br>
-If the test fails hourly rate will be set and method would return true"<br>
* -Expected outcome: SetHourlyRate method should return false
Result: Method returned false, hourlyRate was not set.
*/
        [TestMethod]
        public void testSetHourlyRate()
        {
            var employee = new ParttimeEmployee();
            bool check = employee.SetHourlyRate("3f.34");


            Assert.AreEqual(false, check);
        }

        //seasonal check

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -happy path to see that winter season is accepted <br>
-If the test fails season will not be set and method would return false"<br>
* -Expected outcome: SetSeason method should return true
Result: Method returned true, season was set.
*/
        [TestMethod]
        public void testSetSeason1()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("wiNtEr");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -happy path to see that spring season is accepted <br>
-If the test fails season will not be set and method would return false"<br>
* -Expected outcome: SetSeason method should return true
Result: Method returned true, season was set.
*/
        [TestMethod]
        public void testSetSeason2()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("SPRING");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -happy path to see that summer season is accepted <br>
-If the test fails season will not be set and method would return false"<br>
* -Expected outcome: SetSeason method should return true
Result: Method returned true, season was set.
*/
        [TestMethod]
        public void testSetSeason3()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("SUMMer");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -happy path to see that fall season is accepted <br>
-If the test fails season will not be set and method would return false"<br>
* -Expected outcome: SetSeason method should return true
Result: Method returned true, season was set.
*/
        [TestMethod]
        public void testSetSeason4()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("FaLL");


            Assert.AreEqual(true, check);
        }
        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* - exception check to see if anything but a season is accepted <br>
-If the test fails season will be set and method would return true"<br>
* -Expected outcome: SetSeason method should return false
Result: Method returned false, season was not set.
*/
        [TestMethod]
        public void testSetSeason5()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("Winterrtime");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -exception check to see if invalid characters are handled <br>
-If the test fails season will be set and method would return true"<br>
* -Expected outcome: SetSeason method should return false
Result: Method returned false, season was not set.
*/
        [TestMethod]
        public void testSetSeason6()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("Fa..ll");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting the season for seasonal employees
* \details <b>Details</b>
* -Bounds check to see if a blank entry is accepted<br>
-If the test fails season will not be set and method would return false"<br>
* -Expected outcome: SetSeason method should return true
Result: Method returned true, season was set.
*/
        [TestMethod]
        public void testSetSeason7()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetSeason("");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the piece pay for seasonal employees
* \details <b>Details</b>
* -happy path to see that a positive double is accepted<br>
-If the test fails piece pay will not be set and method would return false"<br>
* -Expected outcome: SetPiecePay method should return true
Result: Method returned true, piecePay was set.
*/
        [TestMethod]
        public void testSetPiecePay1()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetPiecePay("18.89");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the piece pay for seasonal employees
* \details <b>Details</b>
* -bounds check to see that 0 is accepted<br>
-If the test fails piece pay will not be set and method would return false"<br>
* -Expected outcome: SetPiecePay method should return true
Result: Method returned true, piecePay was set.
*/
        [TestMethod]
        public void testSetPiecePay2()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetPiecePay("0");


            Assert.AreEqual(true, check);
        }

        /**
* \brief Method that runs the test for setting the piece pay for seasonal employees
* \details <b>Details</b>
* -bounds check to see that negative values are not accepted<br>
-If the test fails piece pay will be set and method would return true"<br>
* -Expected outcome: SetPiecePay method should return false
Result: Method returned false, piecePay was not set.
*/
        [TestMethod]
        public void testSetPiecePay3()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetPiecePay("-18.98");


            Assert.AreEqual(false, check);
        }

        /**
* \brief Method that runs the test for setting the piece pay for seasonal employees
* \details <b>Details</b>
* -exception check to see that invalid character are not accepted<br>
-If the test fails piece pay will be set and method would return true"<br>
* -Expected outcome: SetPiecePay method should return false
Result: Method returned false, piecePay was not set.
*/
        [TestMethod]
        public void testSetPiecePay4()
        {
            var employee = new SeasonalEmployee();
            bool check = employee.SetPiecePay("1B.33");


            Assert.AreEqual(false, check);
        }
        /**
* \brief All Validate methods need to be manually tested as they do not take any parameters it just checks already inputted attributes
* \details <b>Details</b>
* "<br>
* -Expected outcome: Validate returns true if all attributes are valid and false if any come up invalid.
Result: Method returned true when valid employee attributes were all set.
*/

        /**
* \brief All Details() methods need to be manually tested as they do not take any parameters it just outputs already set attribute values
* \details <b>Details</b>
* "<br>
* -Expected outcome: Method successfully retruns a string formatted to output all attribute values for that class
Result: Method successfully returned a formatted string of all attribute values.
*/


}


}
