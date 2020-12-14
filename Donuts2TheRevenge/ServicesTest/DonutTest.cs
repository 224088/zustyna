using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
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
            donutCRUD.deleteDonut(24);
        
        }

        [TestMethod]
        public void GetDonutsTest()
        {
            donutCRUD.addDonut(24, 3, "last christmas", "magic", 5);
            donutCRUD.addDonut(88, 2, "firendship is magic", "magic", 3);
            donutCRUD.addDonut(116, 6, "all i want for christmas", "magic", 7);

            IEnumerable<donut> donuts = donutCRUD.GetDuntsByFilling("magic");
            Assert.AreEqual(donuts.Count(), 3);
            Assert.AreEqual(donuts.ElementAt(0).donut_name, "last christmas");
            Assert.AreEqual(donuts.ElementAt(1).donut_id, 88);
            Assert.AreEqual(donuts.ElementAt(2).price, 7);


            donutCRUD.deleteDonut(24);
            donutCRUD.deleteDonut(88);
            donutCRUD.deleteDonut(116);
        }

        [TestMethod]
        public void GetAllDonutsTest()
        {
            IEnumerable<donut> donuts = donutCRUD.GetAllDonuts();
            Assert.AreEqual(donuts.Count(), 11);
        }

        [TestMethod]
        public void GetDonutFromDatabseTest()
        {
            Assert.AreEqual(donutCRUD.GetDonut(4).filling, "Cream");
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
