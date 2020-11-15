
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer
{

    public class DataService
    {

        private IDataRepository repository;

        public DataService(IDataRepository repository)
        {
            this.repository = repository;
        }




        /*
         * Tu powinny byc funkcje istotne dla biznesu  GetDonutByType, GetDonutByID
         * Funkcje takie jak update i delete powinny zwracac booleany ze operacja sie powiodla
         *  GetEventsForTheClient, > GetEventsBetween(DateTime start, DateTime end)
         *  GetEventsForTheDonut
         *  BuyingDonut   --> W srodu musi byc tworzenie eventu BuyingEvent, dodawanie go do listy eventow w datacontext, zmienianie stanu sklepu
         *  To samo dla restocking
         *  GetBoughtDonutsAndAmount()
         * 
         */

    }
}
