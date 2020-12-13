using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Data.Linq;

namespace ServicesTest
{
    [TestClass]
    public class DonutTest
    {
        [TestMethod]
        public void AddDonutTest()
        {

            Assert.IsTrue(donutCRUD.addDonut(666, 2, "Devil Wears Prada", "Fashiom", 800));
            
            Assert.IsTrue(donutCRUD.deleteDonut(666));
        }
        [TestMethod]
        public void GetDonutTest()
        {
            donutCRUD.addDonut(24, 3, "last christmas", "magic", 5);
            Assert.AreEqual(donutCRUD.GetDonut(24).donut_id, 24);
            Assert.AreEqual(donutCRUD.GetDonutByName("last christmas").quantity, 3);
            donutCRUD.addDonut(8, 2, "a", "magic", 3);
            donutCRUD.addDonut(16, 6, "aa", "magic", 7);
            //Assert.AreEqual(donutCRUD.GetDuntsByFilling("magic").)
            donutCRUD.deleteDonut(24);
            donutCRUD.deleteDonut(8);
            donutCRUD.deleteDonut(16);
           
           
        }
        
    }
}
