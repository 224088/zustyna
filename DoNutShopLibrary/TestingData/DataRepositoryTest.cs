using System;
using DataLayer;
using DataLayer.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class DataRepositoryTest
    {

        private DataContext our_shop;
        private IDataRepository repository;
        private IGenerator generator;


        [TestInitialize]
        public void Initialize()
        {
            our_shop = new DataContext();
            repository = new DataRepository(our_shop);
            generator = new FixedGenerator();
            generator.GenarateData(our_shop);
        }

        //Customer

        [TestMethod]
        public void CustomerAddAndGet()
        {
            Customer c = new Customer("Olka", "Nowak ", "O7");
            Assert.AreEqual(repository.GetAllCustomersNumber(), 3);
            repository.AddCustomer(c);
            Assert.AreEqual(repository.GetAllCustomersNumber(), 4);
            Customer temp = repository.GetCustomer("O7");
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteCustomerCorrect()
        {

            repository.DeleteCustomer("O1");
            Assert.AreEqual(repository.GetAllCustomersNumber(), 2);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteCustomerException()
        {

            repository.DeleteCustomer("ALALA");
            Assert.AreEqual(repository.GetAllCustomersNumber(), 2);

        }

        [TestMethod]
        public void UpdateInfoCustomer()
        {
            Customer temp = repository.GetCustomer("O1");
            Assert.AreEqual("Ola", temp.FirstName);
            Customer c = new Customer("Olka", "Nowak ", "O1");
            repository.UpdateCustomerInfo(c);
            temp = repository.GetCustomer("O1");
            Assert.AreEqual("Olka", temp.FirstName);
        }

        //donut

        [TestMethod]
        public void DonutAddAndGet()
        {
            Donut c = new Donut("SugarHigh", 999, 12.5, DonutTypeEnum.Chocolate);
            Assert.AreEqual(repository.GetDonutsNumber(), 4);
            repository.AddDonut(c);
            Assert.AreEqual(repository.GetDonutsNumber(), 5);
            Donut temp = repository.GetDonut(999);
            Assert.AreEqual(temp, c);
        }

        [TestMethod]
        public void DeleteDonutCorrect()
        {

            repository.DeleteDonut(2);
            Assert.AreEqual(repository.GetAllCustomersNumber(), 3);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteDonutException()
        {

            repository.DeleteDonut(12345);
            Assert.AreEqual(repository.GetAllCustomersNumber(),4);

        }

        [TestMethod]
        public void UpdateInfoDonut()
        {
            Donut temp = repository.GetDonut(2);
            Assert.AreEqual(7.6, temp.Price);
            Donut c = new Donut("Jam-Packed", 2, 12.9, DonutTypeEnum.Jelly);
            repository.UpdateDonutInfo(c);
            temp = repository.GetDonut(2);
            Assert.AreEqual(12.9, temp.Price);
        }

        [TestMethod]
        public void EventTests()
        {
            Customer temp = repository.GetCustomer("O1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void EventTestsDeleteException()
        {
            Customer temp = repository.GetCustomer("O1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("lalalal");

        }

        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            Customer temp = repository.GetCustomer("O1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", repository.GetState(), temp, now);
            repository.AddEvent(b);
            Assert.AreEqual(repository.GetAllEventsNumber(), 1);
            repository.DeleteEvent("b1");
            Assert.AreEqual(repository.GetAllEventsNumber(), 0);

        }

        //State

        [TestMethod]
        public void StatesTest()
        {
            Assert.AreEqual(repository.GetDonutState(1), 10);
            repository.UpdateDonutStateInfo(1, 7);
            Assert.AreEqual(repository.GetDonutState(1), 7);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void ExceptionNoDonuttodeleteTest()
        {
            Assert.AreEqual(repository.GetDonutState(1), 10);
            repository.DeleteOneDonutState(18181);


        }




    }
}
