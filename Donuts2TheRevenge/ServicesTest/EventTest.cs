using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;

namespace ServicesTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void AddEventTest()
        {

            Assert.IsTrue(EventCRUD.addEvent(9, DateTime.Now, true, 6, 7, 5));
            Assert.IsTrue(EventCRUD.deleteEvent(9));
        }
        [TestMethod]
        public void GetEventTest()
        { 
            EventCRUD.addEvent(17, DateTime.Now, false, 72, 4,5 );
            Assert.AreEqual(EventCRUD.GetEvent(17).amount, 72);
            //Assert.AreEqual(EventCRUD.GetEventByTime(DateTime.????).event_id, 17);
            EventCRUD.deleteEvent(17);

        }

        [TestMethod]
        public void UpdateEventTest()
        {
            EventCRUD.addEvent(68, DateTime.Now, true, 55, 4, 5);
            Assert.IsTrue(EventCRUD.updateAmount(68, 76));
            Assert.AreEqual(EventCRUD.GetEvent(68).amount, 76);
            Assert.IsTrue(EventCRUD.updateDonut(68, 7));
            Assert.AreEqual(EventCRUD.GetEvent(68).donut, 7);
            Assert.IsTrue(EventCRUD.updateCustomer(68, 6));
            Assert.AreEqual(EventCRUD.GetEvent(68).customer, 6);
            EventCRUD.deleteEvent(68);
            
            //brakuje type i czas
        }
    }
}
