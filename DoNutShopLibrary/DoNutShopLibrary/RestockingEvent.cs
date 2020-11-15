using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class RestockingEvent : Event
    {
        public RestockingEvent(string id, StateOfSHOP state, Customer customer, DateTime dateTime) : base(id, state, customer, dateTime)
        {
        }
    }
}
