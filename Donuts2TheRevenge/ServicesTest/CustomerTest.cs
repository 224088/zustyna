using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;

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
    }
}
