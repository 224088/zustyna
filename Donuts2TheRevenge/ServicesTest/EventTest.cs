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

            //brakuje czas
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            EventCRUD.addEvent(89, DateTime.Now, false, 75, 7, 6);
            EventCRUD.addEvent(90, DateTime.Now, true, 75, 7, 5);
            EventCRUD.addEvent(91, DateTime.Now, false, 13, 8, 6);
            EventCRUD.addEvent(92, DateTime.Now, false, 11, 7, 5);

            IEnumerable<@event> events = EventCRUD.GetAllEvents();
            Assert.AreEqual(events.Count(), 4);
            Assert.AreEqual(events.ElementAt(0).event_id, 89);

            EventCRUD.deleteEvent(89);
            EventCRUD.deleteEvent(90);
            EventCRUD.deleteEvent(91);
            EventCRUD.deleteEvent(92);
        }

        [TestMethod]
        public void GetEventsByAmountTest()
        {
            EventCRUD.addEvent(89, DateTime.Now, false, 75, 7, 6);
            EventCRUD.addEvent(90, DateTime.Now, true, 75, 7, 5);
            EventCRUD.addEvent(91, DateTime.Now, false, 13, 8, 6);
            EventCRUD.addEvent(92, DateTime.Now, false, 11, 7, 5);

            IEnumerable<@event> events = EventCRUD.GetEventsByAmount(75);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(1).event_id, 90);

            EventCRUD.deleteEvent(89);
            EventCRUD.deleteEvent(90);
            EventCRUD.deleteEvent(91);
            EventCRUD.deleteEvent(92);
        }

        [TestMethod]
        public void GetEventsByCustomerTest()
        {
            EventCRUD.addEvent(89, DateTime.Now, false, 75, 7, 6);
            EventCRUD.addEvent(90, DateTime.Now, true, 75, 7, 5);
            EventCRUD.addEvent(91, DateTime.Now, false, 13, 8, 6);
            EventCRUD.addEvent(92, DateTime.Now, false, 11, 7, 5);

            IEnumerable<@event> events = EventCRUD.GetEventsByCustomer(5);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).event_id, 90);
            Assert.AreEqual(events.ElementAt(1).event_id, 92);

            EventCRUD.deleteEvent(89);
            EventCRUD.deleteEvent(90);
            EventCRUD.deleteEvent(91);
            EventCRUD.deleteEvent(92);
        }

        [TestMethod]
        public void GetEventsByDonutsTest()
        {
            EventCRUD.addEvent(89, DateTime.Now, false, 75, 7, 6);
            EventCRUD.addEvent(90, DateTime.Now, true, 75, 7, 5);
            EventCRUD.addEvent(91, DateTime.Now, false, 13, 8, 6);
            EventCRUD.addEvent(92, DateTime.Now, false, 11, 7, 5);

            IEnumerable<@event> events = EventCRUD.GetEventsByDonut(7);
            Assert.AreEqual(events.Count(), 3);
            Assert.AreEqual(events.ElementAt(0).customer, 6);
            Assert.AreEqual(events.ElementAt(2).event_id, 92);

            EventCRUD.deleteEvent(89);
            EventCRUD.deleteEvent(90);
            EventCRUD.deleteEvent(91);
            EventCRUD.deleteEvent(92);
        }

        [TestMethod]
        public void GetEventsByTypeTest()
        {
            EventCRUD.addEvent(89, DateTime.Now, false, 75, 7, 6);
            EventCRUD.addEvent(90, DateTime.Now, false, 75, 7, 5);
            EventCRUD.addEvent(91, DateTime.Now, true, 13, 8, 6);
            EventCRUD.addEvent(92, DateTime.Now, false, 11, 7, 5);

            IEnumerable<@event> events = EventCRUD.GetEventsByType(true);
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).amount, 13);
            

            EventCRUD.deleteEvent(89);
            EventCRUD.deleteEvent(90);
            EventCRUD.deleteEvent(91);
            EventCRUD.deleteEvent(92);
        }

        [TestMethod]
        public void GetEventsByTimeTest()
        {
            IEnumerable<@event> events = EventCRUD.GetEventsByTime(DateTime.Now);
            Assert.AreEqual(events.Count(), 0);
        }

        [TestMethod]
        public void GetEventFromDatabaseTest()
        {
            //Assert.AreEqual(EventCRUD.GetEvent(7).customer, 6);
        }
    }
}
