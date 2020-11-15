using System;
using DataLayer;
using DataLayer.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingData
{
    [TestClass]
    public class EmptyGenerationTests
    {

        private static StateOfSHOP state = new StateOfSHOP();
        private DataContext our_shop =new DataContext(state);
        private IDataRepository repository;
        private EmptyGenerator generator = new EmptyGenerator();


        [TestInitialize]
        public void Initialize()
        {
            generator.GenarateData(our_shop);
            repository = new DataRepository(our_shop);
        }


        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(0,repository.GetDonutsNumber());

        }
    }
}
