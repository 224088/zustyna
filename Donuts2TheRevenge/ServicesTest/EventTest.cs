using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            EventCRUD.addEvent(17, DateTime.Now, false, 72, 4, 5);
            Assert.AreEqual(EventCRUD.GetEvent(17).amount, 72);
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
            Assert.IsTrue(EventCRUD.updateType(68, false));
            Assert.AreEqual(EventCRUD.GetEvent(68).is_stocking_event, false);
            Assert.IsTrue(EventCRUD.updateTime(68, DateTime.Now));
            EventCRUD.deleteEvent(68);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            

            IEnumerable<@event> events = EventCRUD.GetAllEvents();
            Assert.AreEqual(events.Count(), 3);
            Assert.AreEqual(events.ElementAt(0).event_id, 1);

        }

        [TestMethod]
        public void GetEventsByAmountTest()
        {
            

            IEnumerable<@event> events = EventCRUD.GetEventsByAmount(20);
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).event_id, 3);

            
        }

        [TestMethod]
        public void GetEventsByCustomerTest()
        {

            IEnumerable<@event> events = EventCRUD.GetEventsByCustomer(5);
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).event_id, 1);


        }

        [TestMethod]
        public void GetEventsByDonutsTest()
        {
            IEnumerable<@event> events = EventCRUD.GetEventsByDonut(11);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).customer, 7);
            Assert.AreEqual(events.ElementAt(1).event_id, 3);

        }

        [TestMethod]
        public void GetEventsByTypeTest()
        {
 
            IEnumerable<@event> events = EventCRUD.GetEventsByType(false);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).amount, 3);
            Assert.AreEqual(events.ElementAt(1).customer, 7);

        }

        [TestMethod]
        public void GetEventsByTimeTest()
        {
            IEnumerable<@event> events = EventCRUD.GetEventsByTime(DateTime.Now);
            Assert.AreEqual(events.Count(), 0);
        }

        [TestMethod]
        public void GetEventsByCustomerNameTest()
        {


            IEnumerable<@event> events = EventCRUD.GetEventsByCustomerName("Paris", "Hilton");
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).amount, 20);


        }


        [TestMethod]
        public void GetEventFromDatabaseTest()
        {
            Assert.AreEqual(EventCRUD.GetEvent(2).customer, 7);
        }
    }
}
