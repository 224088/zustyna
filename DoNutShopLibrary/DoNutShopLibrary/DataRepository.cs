using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class DataRepository : IDataRepository
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }


        //C.R.U.D. (Create, Read, Update, Delete)
        /* (Add) Dodawanie nowych danych do kolekcji
        (Get) Odczyt pojedynczych obiektów, np. na podstawie identyfikatora lub pozycji w kolekcji
        (GetAll) Odczyt wszystkich obiektów z kolekcji
        (Update) Aktualizacja danych w kolekcji - opcjonalnie, podając obiekt lub pozycję w kolekcji
        (Delete) Usuwanie wskazanych danych z kolekcji - podając obiekt lub pozycję w kolekcji
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
            throw new Exception("There is no Customer with this ID");
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

        #region Donut

        public int ProductCounter { get => ProductCounter; set => ProductCounter = value; }

        public void AddDonut(Donut d)

        {
            context.products.Add(ProductCounter, d);
            ProductCounter++;

        }

        public Donut GetDonut(int id)
        {
            return context.products[id];
        }

        public IEnumerable<Donut> GetAllDonuts()
        {
            return context.products.Values;
        }

        public void UpdateDonutInfo(Donut D)
        {
            if (context.products.ContainsKey(D.Id))
            {

                context.products[D.Id].Name = D.Name;
                context.products[D.Id].Price = D.Price;
                context.products[D.Id].Filling = D.Filling;
            }
            throw new Exception("Such Donut with does not exist in our DoNot Shop");
        }

        public void DeleteDonut(int id)
        {
            if (context.products.ContainsKey(id))
            {
                context.products.Remove(id);
            }
            throw new Exception("Donut with such id does not exist");
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

    }

    #endregion




}




