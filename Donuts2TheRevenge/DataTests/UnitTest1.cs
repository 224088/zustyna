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
        static private string GetConnectionString()
        {
            return "Data Source=DESKTOP-56T1RJQ; AttachDbFilename =donut.mdf; Integrated Security = True";
        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        [TestMethod]
        public void AddDOnutToDatabase()
        {
            //OpenSqlConnection();

            DataClasses1DataContext database = new DataClasses1DataContext();

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

     /*   [TestMethod]
        public void fetchFromDBTest()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();

            Customers customer = db.Customers.FirstOrDefault(c => c.id.Equals(100));
            Assert.AreEqual(customer.id, 100);
            Assert.AreEqual(customer.name, "John");
            Assert.AreEqual(customer.money, 100);

        }*/
    }
}
