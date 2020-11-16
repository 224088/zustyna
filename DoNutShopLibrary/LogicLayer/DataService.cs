
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer
{

    public class DataService
    {

        private IDataRepository repository;

        public DataService(IDataRepository repository)
        {
            this.repository = repository;
        }

        //Donut

        public Donut GetDonutByType(DonutTypeEnum type)
        {
            return repository.GetDonutByType(type);
        }
        public Donut GetDonutById(int id)
        {
            return repository.GetDonut(id);
        }
        public int GetDonutByNumber()
        {
            return repository.GetDonutsNumber();
        }
        public int GetDonutByState(int id)
        {
            return repository.GetDonutState(id);
        }

        public void AddDonut(Donut donut)
        {
         repository.AddDonut(donut);
        }

        public void DeleteDonut(int id)
        {
            repository.DeleteDonut(id);
        }

        //Customer
        public void GetCustomerById(string id)
        {
            repository.GetCustomer(id);
        }
        public void AddCustomer(Customer customer)
        {
            repository.AddCustomer(customer);
        }
        
        public void UpdateCustomerInfo(Customer C)
        {
            repository.UpdateCustomerInfo(C);
        }

        public void DeleteCustomer(String id)
        {
            repository.DeleteCustomer(id);
        }
        //State

        public int GetDonutState(int id)
        {
            return repository.GetDonutState(id);
        }
        public StateOfSHOP GetState()
        {
            return repository.GetState();
        }


        public void UpdateDonutStateInfo(int ID, int new_state)
        {
            repository.UpdateDonutStateInfo(ID, new_state);
        }

        public void DeleteOneDonutState(int id)
        {
            repository.DeleteOneDonutState(id);
            
        }
        //Event

        public void AddEvent(Event myEvent)
        {
            repository.AddEvent(myEvent);
        }
        public void DeleteEvent(string id)
        {
            repository.DeleteEvent(id);
        }
        public void GetEventByID(string id)
        {
            repository.GetEventById(id);
        }
        public IEnumerable<Event> GetEventsBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            List<Event> allEvents = new List<Event>();

            foreach (Event myEvent in repository.GetAllEvents())
            {
                if (myEvent.dateTime >= startDate && myEvent.dateTime <= endDate)
                {
                    allEvents.Add(myEvent);
                }
            }
            return allEvents;
        }

        public IEnumerable<Event> GetEventsForTheClient(string id)
        {
            Customer client = repository.GetCustomer(id);
            List<Event> allEvents = new List<Event>();

            foreach (Event myEvent in repository.GetAllEvents())
            {
                if (myEvent.customer.Equals(client))
                {
                    allEvents.Add(myEvent);
                }
            }
            return allEvents;
        }
     
        public void BuyDonut(string customerid, int donutid, DateTime dayOfBuying, int amountOfDonuts)
        {
            Customer client = repository.GetCustomer(customerid);
            Donut donut = repository.GetDonut(donutid);
            int amountLeft = GetDonutState(donutid) - amountOfDonuts;
            if (GetDonutState(donutid) < amountOfDonuts)
            {
                throw new InvalidOperationException("There is not enough donuts in the shop.");
            }

            BuyingEvent buyEvent = new BuyingEvent(customerid, GetState(), client, dayOfBuying);
            repository.AddEvent(buyEvent);
            UpdateDonutStateInfo(donutid, amountLeft);
            
        }
           

        


        /*
         //* Tu powinny byc funkcje istotne dla biznesu  GetDonutByType, GetDonutByID +
         * Funkcje takie jak update i delete powinny zwracac booleany ze operacja sie powiodla -/+
         //*  GetEventsForTheClient, > GetEventsBetween(DateTime start, DateTime end) +
        // *  GetEventsForTheDonut -
         *  BuyingDonut   --> W srodu musi byc tworzenie eventu BuyingEvent, dodawanie go do listy eventow w datacontext, zmienianie stanu sklepu
         *  To samo dla restocking
         *  GetBoughtDonutsAndAmount()
         * 
         */

    }
}
