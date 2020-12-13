using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Linq;

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
            donutCRUD.addDonut(88, 2, "a", "magic", 3);
            donutCRUD.addDonut(116, 6, "aa", "magic", 7);
            //Assert.AreEqual(donutCRUD.GetDuntsByFilling("magic").Count, 3);
            donutCRUD.deleteDonut(24);
            donutCRUD.deleteDonut(88);
            donutCRUD.deleteDonut(116);
          
        }

        [TestMethod]
        public void UpdateDonutTest()
        {
            donutCRUD.addDonut(18, 7, "friendship is magic", "magic", 12);
            Assert.IsTrue(donutCRUD.updateFilling(18, "friendship"));
            Assert.AreEqual(donutCRUD.GetDonut(18).filling, "friendship");
            Assert.IsTrue(donutCRUD.updateName(18, "relationship?"));
            Assert.AreEqual(donutCRUD.GetDonut(18).donut_name, "relationship?");
            Assert.IsTrue(donutCRUD.updatePrice(18, 6));
            Assert.AreEqual(donutCRUD.GetDonut(18).price,6);
            Assert.IsTrue(donutCRUD.updateQuantity(18, 90));
            Assert.AreEqual(donutCRUD.GetDonut(18).quantity, 90);
            donutCRUD.deleteDonut(18);
        }
    }
}
