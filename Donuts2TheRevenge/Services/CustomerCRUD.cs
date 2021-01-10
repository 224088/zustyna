using Data;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
   public class CustomerCRUD
    {
        public CustomerCRUD()
        {
        }
        static public bool addCustomer(int id, string name, string surname)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                customer newCustomer = new customer
                {
                customer_id = id,
                customer_f_name = name,
                customer_l_name = surname

                };
                context.customer.InsertOnSubmit(newCustomer);
                context.SubmitChanges();

            return true;
            }

        }
        static public bool deleteCustomer(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                customer mycustomer = context.customer.SingleOrDefault(customer => customer.customer_id == id); //tu patrzyłam na różne metody żeby zmienić ale tylko ta się nadaje
                context.customer.DeleteOnSubmit(mycustomer);
                context.SubmitChanges();
                return true;
            }
        }
        static public bool updateName(int id, string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                customer mycustomer = context.customer.SingleOrDefault(customer => customer.customer_id == id);
                mycustomer.customer_f_name = name;
                context.SubmitChanges();
                return true;
            }
        }
        static public bool updateLastName(int id, string surname)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                customer mycustomer = context.customer.SingleOrDefault(customer => customer.customer_id == id);
                mycustomer.customer_l_name = surname;
                context.SubmitChanges();
                return true;
            }
        }

        static public customer GetCustomer(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (customer customer in context.customer.ToList())
                {
                    if (customer.customer_id == id)
                    {
                        return customer;
                    }
                }
                return null;
            }
        }

        static public customer GetCustomerByLastName(string lname)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (customer customer in context.customer.ToList())
                {
                    if (customer.customer_l_name == lname)
                    {
                        return customer;
                    }
                }
                return null;
            }
        }

        static public List<Dictionary<string, string>> GetCustomersInfo()

        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            List<customer> tempC = GetAllCustomers().ToList();
            foreach (customer customer in tempC)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("f_name", customer.customer_f_name);
                temp.Add("id", customer.customer_id.ToString());
                temp.Add("l_name", customer.customer_l_name);
               
                returnList.Add(temp);

            }
            return returnList;
        }

        static public IEnumerable<customer> GetCustomersByName(string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<customer> result = new List<customer>();
                foreach (customer customer in context.customer)
                {
                    if (customer.customer_f_name.Equals(name))
                    {
                        result.Add(customer);
                    }
                }
                return result;
            }
        }

        static public customer GetCustomerByNames(string name, string surname)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (customer customer in context.customer.ToList())
                {
                    if (customer.customer_f_name== name && customer.customer_l_name==surname)
                    {
                        return customer;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<customer> GetAllCustomers()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.customer.ToList();
                return result;
            }
        }
    }

}
