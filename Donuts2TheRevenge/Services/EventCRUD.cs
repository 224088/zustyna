using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EventCRUD
    {
        public EventCRUD()
        {

        }

        public bool addEvent(int id, DateTime time, bool isStocking, int count, int don, int client) 
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event newevent = new @event
                {
                    event_id = id,
                    event_time = time,
                    is_stocking_event = isStocking,
                    amount = count,
                    donut  = don,
                    customer = client


                };
                context.@event.InsertOnSubmit(newevent);
                context.SubmitChanges();

                return true;
            }

        }

        public bool deleteEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id); //tu patrzyłam na różne metody żeby zmienić ale tylko ta się nadaje
                context.@event.DeleteOnSubmit(myEvent);
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateTime(int id, DateTime time)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.event_time= time;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateType(int id, bool stocking)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.is_stocking_event = stocking;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateAmount(int id, int number)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.amount = number;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateDonut(int id, int don)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.donut = don;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateCustomer(int id, int client)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.customer = client;
                context.SubmitChanges();
                return true;
            }
        }

        public @event GetEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (@event myevent in context.@event.ToList())
                {
                    if (myevent.event_id == id)
                    {
                        return myevent;
                    }
                }
                return null;
            }
        }

        public @event GetEventByTime(DateTime time)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (@event myevent in context.@event.ToList())
                {
                    if (myevent.event_time == time)
                    {
                        return myevent;
                    }
                }
                return null;
            }
        }

        public IEnumerable<@event> GetAllCustomers()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.@event.ToList();
                return result;
            }
        }

        public IEnumerable<@event> GetEventsByType(bool type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();
                foreach (@event myevent in context.@event)
                {
                    if (myevent.is_stocking_event.Equals(type))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }
        public IEnumerable<@event> GetEventsByDonut(int don)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();
                foreach (@event myevent in context.@event)
                {
                    if (myevent.donut.Equals(don))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }
        public IEnumerable<@event> GetEventsByCustomer(int client)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();
                foreach (@event myevent in context.@event)
                {
                    if (myevent.customer.Equals(client))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }

        public IEnumerable<@event> GetEventsByAmount(int number)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();
                foreach (@event myevent in context.@event)
                {
                    if (myevent.amount.Equals(number))
                    {
                        result.Add(myevent);
                    }
                }
                return result;
            }
        }


    }
}
