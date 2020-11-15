using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class BuyingEvent : Event
    {
        public BuyingEvent(string id, StateOfSHOP state, Customer customer, DateTime dateTime) : base(id, state, customer, dateTime)
        {
    

        }
    }
}
