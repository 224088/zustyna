using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DataRepository : IDataRepository
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }


        //C.R.U.D. (Create, Read, Update, Delete)
        /*  (ADD) create or add new entries;
            (GET and GETALL) read, retrieve, search, or view existing entries;
            (UPDATE) update or edit existing entries;
            (DELETE) delete, deactivate, or remove existing entries.
         */


        #region Customer
        public void AddCustomer(Customer c)
        {
            context.clients.Add(c);
        }

        public Customer GetCustomer(String id)
        {
            foreach (Customer C in context.clients)
            {
                if (C.Id == id)
                {
                    return C;
                }
            }
            throw new Exception("There is no Customer with this ID");
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.clients;
        }

        public int GetAllCustomersNumber()
        {
            return context.clients.Count;
        }



        public void UpdateCustomerInfo(Customer C)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == C.Id)
                {
                    context.clients[i].FirstName = C.FirstName;
                    context.clients[i].LastName = C.LastName;
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        public void DeleteCustomer(String id)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == id)
                {
                    context.clients.Remove(context.clients[i]);
                    return;
                }
            }
            throw new Exception("Client with such ID does not exist");
        }

        #endregion

        #region Donut CAtalog

        public void AddDonut(Donut d)

        {
            if (context.catalog.products.ContainsKey(d.Id))
            {
                throw new Exception("No such Donut in our DONOT shop");
            }
                context.catalog.products.Add(d.Id, d);
        }

        public int GetDonutsNumber()
        {
            return context.catalog.products.Count();

        }

        public Donut GetDonut(int id)
        {
            return context.catalog.products[id];
        }
        public Donut GetDonutByType(DonutTypeEnum type)
        {
            foreach (var donut in context.catalog.products.ToArray())
            {
                if (context.catalog.products[donut.Key].Filling == type)
                {
                    return context.catalog.products[donut.Key];
                }
            }
            throw new Exception("There is no donut with this filling in the shop");
        }
        public IEnumerable<Donut> GetAllDonuts()
        {
            return context.catalog.products.Values;
        }

        public void UpdateDonutInfo(Donut D)
        {
            if (context.catalog.products.ContainsKey(D.Id))
            {

                context.catalog.products[D.Id].Name = D.Name;
                context.catalog.products[D.Id].Price = D.Price;
                context.catalog.products[D.Id].Filling = D.Filling;
                return;
            }
            throw new Exception("No such Donut in our DONOT shop");
        }

        public void DeleteDonut(int id)
        {
            if (context.catalog.products.ContainsKey(id))
            {
                context.catalog.products.Remove(id);
                return;
            }
            throw new Exception("There already is no such donut");
        }

        #endregion

        #region Event

        public List<Event> GetAllEvents()
        {
            return context.events;
        }

        public int GetAllEventsNumber()
        {
            return context.events.Count;
        }

        public Event GetEventById(String id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    return context.events[i];
                }
            }
            throw new Exception("Event with such id does not exist");
        }


        public void AddEvent(Event e)
        {
            context.events.Add(e);
        }

        public void DeleteEvent(String id)
        {
            for (int i = 0; i < context.events.Count; i++)
            {
                if (context.events[i].Id == id)
                {
                    context.events.Remove(context.events[i]);
                    return;
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        #endregion

        #region State

        public int GetDonutState(int id)
        {
            return context.shop.inventory[id];
        }

        public StateOfSHOP GetState()
        {
            return context.shop;
        }

        public Dictionary<int, int> GetAllStates()
        {
            return context.shop.inventory;
        }

        public void UpdateDonutStateInfo(int ID, int new_state)
        {
            if (context.catalog.products.ContainsKey(ID))
            {

                context.shop.inventory[ID] = new_state;
                return;
            }
            throw new Exception("No dounut With such ID");
        }

        public void DeleteOneDonutState(int id)
        {
            if (context.shop.inventory.ContainsKey(id))
            {
                context.shop.inventory.Remove(id);
                return;
            }
            throw new Exception("There already is no such donut");
        }

        #endregion






    }
    }




