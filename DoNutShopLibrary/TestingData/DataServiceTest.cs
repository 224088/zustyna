using System;
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

	/*	[TestMethod]
		public void CustomerAddAndGet()
		{
			Customer c = new Customer("Marcela", "Kozak ", "M6");
			Assert.AreEqual(service.GetAllCustomersNumber(), 3);
			service.AddCustomer(c);
			Assert.AreEqual(service.GetAllCustomersNumber(), 4);
			Customer temp = service.GetCustomer("O7");
			Assert.AreEqual(temp, c);
		}*/

		[TestMethod]
		public void DonutTest()
        {
			Donut donut = new Donut("color me impressed", 457, 6.77, DonutTypeEnum.Caramel);
			service.AddDonut(donut);
			Assert.AreEqual(donut, service.GetDonutById(457));
			service.DeleteDonut(457);
			
		}

		[TestMethod]
		public void BuyDonutsTest()
		{
			Customer customer = new Customer("Wanda", "Owca", "W5");
			service.AddCustomer(customer);
			Donut donut = new Donut("Peanut butter&", 876, 8.77, DonutTypeEnum.Jelly);
			DateTime now = DateTime.Now;
			//service.AddDonut(donut);
			//service.UpdateDonutStateInfo(876, 50);
			service.AddandUpdate(donut, 50);
			int stateThen = service.GetStateOfDonut(876);
			service.BuyDonut("W5", 876 , now, 17);
			Assert.AreEqual(stateThen - 17, service.GetStateOfDonut(876));

		}

		/*[TestMethod]

		public void RestockTest()
        {
			Customer supplier = new Customer("Britney", "Spears", "B11");
			Donut donut = new Donut("Hit me baby one more time", 997, 4.20, DonutTypeEnum.Vanilla);
			DateTime now = DateTime.Now;
			service.UpdateDonutStateInfo(997, 0);
			int stateThen = service.GetStateOfDonut(997);
			service.Restock("B11", 997, now, 112);
			Assert.AreEqual(stateThen + 112, service.GetStateOfDonut(997));
		}*/
	}
}
