using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Data;
using System.Data.SqlClient;
using Rescources;


namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        SQLString S = new SQLString();

        [TestMethod]
        public void AddDOnutToDatabase()
        {
            //OpenSqlConnection();

            
            
            using (DataClasses1DataContext database = new DataClasses1DataContext(S.GetString()))
            {

                donut donut = new donut();
                donut.donut_id = 2;
                donut.donut_name = "FilledWithJoy";
                donut.filling = "Joy";
                donut.price = 8;
                donut.quantity = 0;





                database.donut.InsertOnSubmit(donut);
                database.SubmitChanges();



                donut mydonut = database.donut.FirstOrDefault(doonut => doonut.donut_id.Equals(2));
                Assert.AreEqual(mydonut.donut_id, 2);
                Assert.AreEqual(mydonut.donut_name, "FilledWithJoy");
                Assert.AreEqual(mydonut.filling, "Joy");
                Assert.AreEqual(mydonut.price, 8);
                Assert.AreEqual(mydonut.quantity, 0);



                database.donut.DeleteOnSubmit(donut);
                database.SubmitChanges();
            }
        }

           [TestMethod]
             [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
           public void ConnectingToNonExsistingDB()
           {
            //using (DataClasses1DataContext fake = new DataClasses1DataContext("Data Source = DESKTOP-H5C7HVQ; Initial Catalog = NoNexistant; Integrated Security = True"))
            using (DataClasses1DataContext fake = new DataClasses1DataContext(S.GetString()))
            {

                donut donut = new donut();
                donut.donut_id = 2;
                donut.donut_name = "FilledWithJoy";
                donut.filling = "Joy";
                donut.price = 8;
                donut.quantity = 0;




                fake.donut.InsertOnSubmit(donut);
                fake.SubmitChanges();
            }

           }
    }
}
