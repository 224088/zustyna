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

		[TestMethod]
		public void BuyDonutsTest()
		{
			Customer customer = new Customer("Wanda", "Owca", "W5");
			service.AddCustomer(customer);
			Donut donut = new Donut("Peanut butter&", 876, 8.77, DonutTypeEnum.Jelly);
			DateTime now = DateTime.Now;
			service.AddDonut(donut);
			int stateThen = service.GetStateOfDonut(1);
			service.BuyDonut("W5", 1, now, 17);
			Assert.AreEqual(stateThen - 17, service.GetStateOfDonut(876));

		}
	}
}
