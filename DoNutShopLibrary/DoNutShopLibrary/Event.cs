using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    abstract class Event
    {
        public String Id { get; set; }
        protected DateTime dateTime { get; }
        protected State state { get; set; }
        protected Customer customer { get; set; }

        //constructor 
        public Event(string id, State state, Customer customer, DateTime dateTime)
        {
            this.Id = id;
            this.state = state;
            this.customer = customer;
            this.dateTime = dateTime;

        }


        //generated equals method
        public override bool Equals(object obj)
        {
            var @event = obj as Event;
            return @event != null &&
                   Id == @event.Id;
        }
    }
}
