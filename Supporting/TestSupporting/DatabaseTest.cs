using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supporting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void TestDatabase()
        {
           List<string> data = new List<string>();
           TestLoad(data);
          // TestSave(data);
           //TestDelete();
           //TestReload(data);
        }
        /**
* \brief Method that runs the test for reloading the database (saving and then loading)
* \details <b>Details</b>
* -Tests both the saving methods and the loading method.<br>
  -If the test fails data[0] will be equal to "ERROR"<br>
* -Expected outcome: List<string> data should contain all of the employee information
*/
        private void TestReload(List<string> data)
        {
            data = Database.ReloadDatabase(data);
            Assert.AreNotEqual(data[0], "ERROR");
        }

        /**
* \brief Method that runs the test for deleting the database text file
* \details <b>Details</b>
* -Tests the deletion of the database.<br>
-If the test fails success will equal false<br>
* -Expected outcome: bool success will equal true and the database text file deleted
*/
        private void TestDelete()
        {
            bool success = Database.DeleteDatabase();
            Assert.AreEqual(success, true);
        }

        /**
* \brief Method that runs the test for saving the database to the database file
* \details <b>Details</b>
* -Tests the saving method.<br>
-If the test fails success will equal false"<br>
* -Expected outcome: success equals true and the data saved to the database file
*/
        private void TestSave(List<string> data)
        {
            data.Add("Test1");
            data.Add("Test2");
            bool success = Database.SaveDatabase(data);
            Assert.AreEqual(success, true);
        }

        /**
* \brief Method that runs the test for loading the database
* \details <b>Details</b>
* -Tests the loading method.<br>
-If the test fails data[0] will be equal to "ERROR"<br>
* -Expected outcome: List<string> data should contain all of the employee information
*/
        private void TestLoad(List<string> data)
        {
            data = Database.LoadDatabase("database.txt");
            Assert.AreNotEqual(data[0], "ERROR");
        }
    }
}
