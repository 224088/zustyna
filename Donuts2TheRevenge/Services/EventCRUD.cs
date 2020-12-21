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

        static public bool addEvent(int id, DateTime time, bool isStocking, int count, int don, int client) 
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

        static public bool deleteEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id); //tu patrzyłam na różne metody żeby zmienić ale tylko ta się nadaje
                context.@event.DeleteOnSubmit(myEvent);
                context.SubmitChanges();
                return true;
            }
        }


        static public void DeleteEventsForCustomer(int Id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                IEnumerable<@event> events = context.@event.Where(e => e.customer == Id);
                foreach (@event e in events)
                {
                    context.@event.DeleteOnSubmit(e);
                    context.SubmitChanges();
                }
            }
        }
        static public bool updateTime(int id, DateTime time)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.event_time= time;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateType(int id, bool stocking)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.is_stocking_event = stocking;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateAmount(int id, int number)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.amount = number;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateDonut(int id, int don)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.donut = don;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateCustomer(int id, int client)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);
                myEvent.customer = client;
                context.SubmitChanges();
                return true;
            }
        }

        static public @event GetEvent(int id)
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


        static public IEnumerable<@event> GetAllEvents()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.@event.ToList();
                return result;
            }
        }

        static public IEnumerable<@event> GetEventsByTime(DateTime date)
        {
            using (var context = new DataClasses1DataContext())
            {
                List<@event> events = new List<@event>();
                foreach (@event eveent in context.@event.ToList())
                {
                    if (eveent.event_time == date)
                    {
                        events.Add(eveent);
                    }
                }
                return events;
            }
        }

        static public IEnumerable<@event> GetEventsByType(bool type)
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
         static public IEnumerable<@event> GetEventsByDonut(int don)
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
         static public IEnumerable<@event> GetEventsByCustomer(int client)
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

        static public IEnumerable<@event> GetEventsByCustomerName(string name, string surname)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
               customer customer = CustomerCRUD.GetCustomerByNames(name,surname);

                List<@event> events = new List<@event>();
                foreach (@event eveent in context.@event.ToList())
                {
                    if (eveent.customer == customer.customer_id)
                    {
                        events.Add(eveent);
                    }
                }
                return events;
            }
        }

        static public IEnumerable<@event> GetEventsByAmount(int number)
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

        static public bool BuyDonut(int id, donut d, customer c, int amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (d != null && c != null)
                {
                    if (d.quantity > 0 && d.quantity>amount)
                    {

                        addEvent(id,DateTime.Today, false, amount ,d.donut_id, c.customer_id);
                        d.quantity = d.quantity - amount;
                        donutCRUD.updateQuantity(d.donut_id, d.quantity);
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
