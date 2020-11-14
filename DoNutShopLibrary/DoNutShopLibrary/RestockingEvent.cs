using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class RestockingEvent : Event
    {
        public RestockingEvent(string id, State state, Customer customer, DateTime dateTime) : base(id, state, customer, dateTime)
        {
        }
    }
}
