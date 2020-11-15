using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     public class DataContext

    {
        public Catalog catalog = new Catalog();
        public List <Event> events = new List<Event>();
        public StateOfSHOP shop;
        public List <Customer> clients = new List<Customer>();

        public DataContext(StateOfSHOP shop)
        {
            this.shop = shop;
        }
    }
}
