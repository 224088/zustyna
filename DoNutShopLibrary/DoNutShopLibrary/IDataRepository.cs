using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     interface IDataRepository
    {


         void AddCustomer(Customer c);

         Customer GetCustomer(String id);


        IEnumerable<Customer> GetAllCustomers();

        void UpdateCustomerInfo(Customer C);


        void DeleteCustomer(String id);

        void AddDonut(Donut d);



         Donut GetDonut(int id);


         IEnumerable<Donut> GetAllDonuts();

         void UpdateDonutInfo(Donut D);


         void DeleteDonut(int id);


         List<Event> GetAllEvents();


         Event GetEventById(String id);


         void AddEvent(Event e);


         void DeleteEvent(String id);





}
}
