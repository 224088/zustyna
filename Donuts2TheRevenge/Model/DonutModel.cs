using System;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class DonutModel
    {
        public DonutModel()
        {
        }

        public String donut_name { get; set; }
        public int donut_id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public String filling { get; set; }

        public void Converter(Dictionary<String,String> donutInfo)
        {
            donut_id = Int32.Parse(donutInfo["id"]);
            donut_name = donutInfo["name"];
            filling = donutInfo["filling"];
            price = Int32.Parse(donutInfo["price"]);
            quantity = Int32.Parse(donutInfo["quantity"]);
        }


    }
}
