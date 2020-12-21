using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void AddCustomerTest()
        {

            Assert.IsTrue(CustomerCRUD.addCustomer(67, "Michael", "Jackson"));
            Assert.IsTrue(CustomerCRUD.deleteCustomer(67));
        }
        [TestMethod]
        public void GetCustomerTest()
        {
            CustomerCRUD.addCustomer(88, "Joan", "Jett");
            Assert.AreEqual(CustomerCRUD.GetCustomer(88).customer_f_name, "Joan");
            Assert.AreEqual(CustomerCRUD.GetCustomerByLastName("Jett").customer_id, (88));
            Assert.AreEqual(CustomerCRUD.GetCustomerByNames("Joan", "Jett").customer_id, 88);
            CustomerCRUD.deleteCustomer(88);

        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            CustomerCRUD.addCustomer(77, "Ellen", "DeGeneres");
            Assert.IsTrue(CustomerCRUD.updateLastName(77, "Page"));
            Assert.AreEqual(CustomerCRUD.GetCustomer(77).customer_l_name, "Page");
            Assert.IsTrue(CustomerCRUD.updateName(77, "Elliot"));
            Assert.AreEqual(CustomerCRUD.GetCustomerByLastName("Page").customer_f_name, "Elliot");
            CustomerCRUD.deleteCustomer(77);
        }

        [TestMethod]
        public void GetCustomersTest()
        {
            CustomerCRUD.addCustomer(19, "Anna", "Kowalska");
            CustomerCRUD.addCustomer(16, "Anna", "Nowak");

            IEnumerable<customer> customers = CustomerCRUD.GetCustomersByName("Anna");

            Assert.AreEqual(customers.Count(), 2);
            Assert.AreEqual(customers.ElementAt(0).customer_l_name, "Nowak");
            Assert.AreEqual(customers.ElementAt(1).customer_id, 19);

            CustomerCRUD.deleteCustomer(19);
            CustomerCRUD.deleteCustomer(16);
            
        }

        [TestMethod]
        public void GetAllCustomersTest()
        {
            IEnumerable<customer> customers = CustomerCRUD.GetAllCustomers();
            Assert.AreEqual(customers.Count(), 4);
        }

        [TestMethod]
        public void GetCustomerFromDatabseTest()
        {
            Assert.AreEqual(CustomerCRUD.GetCustomer(5).customer_l_name, "Spears");
        }
    }
}
