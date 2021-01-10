using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Model
{
    public class EventModel
    {
        public EventModel()
        {
        }

        public int event_id { get; set; }
        public DateTime event_time { get; set; }
        public Boolean is_stocking_event { get; set; }
        public int amount { get; set; }
        public int donut { get; set; }
        public int customer { get; set; }

        public void Converter(Dictionary<String, String> eventInfo)
        {
            event_id = Int32.Parse(eventInfo["id"]);
            event_time = DateTime.Parse(eventInfo["time"]);
            is_stocking_event = Boolean.Parse(eventInfo["is_stocking"]);
            amount = Int32.Parse(eventInfo["amount"]);
            donut = Int32.Parse(eventInfo["donut"]);
            customer =  Int32.Parse(eventInfo["customer"]);

        }


    }
}
