using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Data;
using System.Data.SqlClient;


namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        

        

        [TestMethod]
        public void AddDOnutToDatabase()
        {
            //OpenSqlConnection();

            using (DataClasses1DataContext database = new DataClasses1DataContext("Data Source=DESKTOP-H5C7HVQ;Initial Catalog=donut;Integrated Security=True"))
            {

                donut donut = new donut();
                donut.donut_id = 2;
                donut.donut_name = "FilledWithJoy";
                donut.fillling = "Joy";
                donut.price = 8;




                database.donut.InsertOnSubmit(donut);
                database.SubmitChanges();



                donut mydonut = database.donut.FirstOrDefault(doonut => doonut.donut_id.Equals(2));
                Assert.AreEqual(mydonut.donut_id, 2);
                Assert.AreEqual(mydonut.donut_name, "FilledWithJoy");
                Assert.AreEqual(mydonut.fillling, "Joy");
                Assert.AreEqual(mydonut.price, 8);



                database.donut.DeleteOnSubmit(donut);
                database.SubmitChanges();
            }
        }

           [TestMethod]
             [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
           public void ConnectingToNonExsistingDB()
           {
            using (DataClasses1DataContext fake = new DataClasses1DataContext("Data Source=DESKTOP-H5C7HVQ;Initial Catalog=WrongNAme;Integrated Security=True"))
            {

                donut donut = new donut();
                donut.donut_id = 2;
                donut.donut_name = "FilledWithJoy";
                donut.fillling = "Joy";
                donut.price = 8;




                fake.donut.InsertOnSubmit(donut);
                fake.SubmitChanges();
            }

           }
    }
}
