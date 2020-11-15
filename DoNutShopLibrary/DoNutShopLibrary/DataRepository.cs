using System;
using System.Collections.Generic;
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

        public void UpdateCustomerInfo(Customer C)
        {
            for (int i = 0; i < context.clients.Count; i++)
            {
                if (context.clients[i].Id == C.Id)
                {
                    context.clients[i].FirstName = C.FirstName;
                    context.clients[i].LastName = C.LastName;
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

        public Donut GetDonut(int id)
        {
            return context.catalog.products[id];
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
            }
            throw new Exception("No such Donut in our DONOT shop");
        }

        public void DeleteDonut(int id)
        {
            if (context.catalog.products.ContainsKey(id))
            {
                context.catalog.products.Remove(id);
            }
            throw new Exception("There already is no such donut");
        }

        #endregion

        #region Event

        public List<Event> GetAllEvents()
        {
            return context.events;
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
                }
            }
            throw new Exception("Event with such id does not exist");
        }

        #endregion

        #region State

        public int GetDonutState(int id)
        {
            return context.shop.Inventory[id];
        }

        public Dictionary<int, int> GetAllStates()
        {
            return context.shop.Inventory;
        }

        public void UpdateDonutStateInfo(int ID, int new_state)
        {
            if (context.catalog.products.ContainsKey(ID))
            {

                context.shop.Inventory[ID] = new_state;
            }
            throw new Exception("No dounut With such ID");
        }

        public void DeleteOneDonutState(int id)
        {
            if (context.shop.Inventory.ContainsKey(id))
            {
                context.shop.Inventory.Remove(id);
            }
            throw new Exception("There already is no such donut");
        }

        #endregion






    }
    }




