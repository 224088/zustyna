using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Model
{
    public class CustomerModel
    {
        public CustomerModel()
        {
        }

        public String customer_f_name { get; set; }
        public String customer_l_name { get; set; }
        public int customer_id { get; set; }


        public void Converter(Dictionary<String, String> customerInfo)
        {
            customer_id = Int32.Parse(customerInfo["id"]);
            customer_f_name = customerInfo["f_name"];
            customer_l_name = customerInfo["l_name"];
           
        }
    }
}
