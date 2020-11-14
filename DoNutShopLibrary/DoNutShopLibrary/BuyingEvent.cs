using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class BuyingEvent : Event
    {
        public BuyingEvent(string id, State state, Customer customer, DateTime dateTime) : base(id, state, customer, dateTime)
        {
    

        }
    }
}
