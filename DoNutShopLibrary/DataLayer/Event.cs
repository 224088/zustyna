using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class Event
    {
        public String Id { get; set; }
        public DateTime dateTime { get; }
        protected StateOfSHOP state { get; set; }
        protected Customer customer { get; set; }

        //constructor 
        public Event(string id, StateOfSHOP state, Customer customer, DateTime dateTime)
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
