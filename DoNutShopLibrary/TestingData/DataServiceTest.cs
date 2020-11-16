using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DataLayer.DataGeneration;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class DataServiceTests
	{

		private DataService service;
		private DataContext our_shop;
		private IGenerator generator;

		[TestInitialize]
		public void Initialize()
		{
			our_shop = new DataContext();
			service = new DataService(new DataRepository(our_shop));
			generator = new FixedGenerator();
			generator.GenarateData(our_shop);
		}

		[TestMethod]
		public void CustomerAddAndGet()
		{
			Customer c = new Customer("Marcela", "Kozak ", "M6");
			Assert.AreEqual(service.GetAllCustomersNumber(), 3);
			service.AddCustomer(c);
			Assert.AreEqual(service.GetAllCustomersNumber(), 4);
			Customer temp = service.GetCustomerById("M6");
			Assert.AreEqual(temp, c);
		}

        [TestMethod]
        public void UpdateInfoCustomer()
        {
          
            Assert.AreEqual("Ola", service.GetCustomerById("O1").FirstName);
            service.UpdateCustomerInfo("Olka", "Nowak ", "O1");
            Assert.AreEqual("Olka", service.GetCustomerById("O1").FirstName);
        }

        [TestMethod]
        public void DeleteCustomerCorrect()
        {

            service.DeleteCustomer("O1");
            Assert.AreEqual(service.GetAllCustomersNumber(), 2);


        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteCustomerException()
        {

            service.DeleteCustomer("ALALA");
            Assert.AreEqual(service.GetAllCustomersNumber(), 2);

        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteDonutException()
        {

            service.DeleteDonut(12345);
            Assert.AreEqual(service.GetAllCustomersNumber(), 4);

        }

        [TestMethod]
		public void DonutTest()
        {
			Donut donut = new Donut("color me impressed", 457, 6.77, DonutTypeEnum.Caramel);
			service.AddDonut(donut);
			Assert.AreEqual(donut, service.GetDonutById(457));
			service.DeleteDonut(457);
			
		}


        [TestMethod]
        public void EventCorrectDeleteTests()
        {
            Customer temp = service.GetCustomerById("O1");
            DateTime now = DateTime.Now;
            Event b = new BuyingEvent("b1", service.GetState(), temp, now);
            service.AddEvent(b);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            service.DeleteEvent("b1");
            Assert.AreEqual(service.GetAllEventsNumber(), 0);

        }


        [TestMethod]
        public void EventUserBuyingTests()
        {
            
            DateTime now = DateTime.Now;
            service.BuyDonut("O1", 1, now, 5);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            Assert.AreEqual(5, service.GetStateOfDonut(1));
            IEnumerable<Event> lista = service.GetEventsForTheClient("O1");
            Assert.AreEqual(1, lista.Count());
            service.BuyDonut("O1", 2, now, 4);
            lista = service.GetEventsForTheClient("O1");
            Assert.AreEqual(2, lista.Count());

        }



        [TestMethod]
		public void BuyDonutsTest()
		{
			Customer customer = new Customer("Wanda", "Owca", "W5");
			service.AddCustomer(customer);
			Donut donut = new Donut("Peanut butter&", 876, 8.77, DonutTypeEnum.Jelly);
			DateTime now = DateTime.Now;
			service.AddandUpdate(donut, 50);
			int stateThen = service.GetStateOfDonut(876);
			service.BuyDonut("W5", 876 , now, 17);
			Assert.AreEqual(stateThen - 17, service.GetStateOfDonut(876));

		}

		[TestMethod]

		public void RestockTest()
        {
			Customer supplier = new Customer("Britney", "Spears", "B11");
            service.AddCustomer(supplier);
            Donut donut = new Donut("Hit me baby one more time", 997, 4.20, DonutTypeEnum.Vanilla);
			DateTime now = DateTime.Now;
            service.AddandUpdate(donut, 0);
			int stateThen = service.GetStateOfDonut(997);
			service.Restock("B11", 997, now, 112);
			Assert.AreEqual(stateThen + 112, service.GetStateOfDonut(997));
		}

        [TestMethod]
        public void EventUserRestockigTests()
        {

            DateTime now = DateTime.Now;
            service.Restock("O1", 1, now, 5);
            Assert.AreEqual(service.GetAllEventsNumber(), 1);
            Assert.AreEqual(15, service.GetStateOfDonut(1));
            IEnumerable<Event> lista = service.GetEventsForTheClient("O1");
            Assert.AreEqual(1, lista.Count());
           

        }
    }
}
