using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer


    //Dobra po doczytaniu instrukcji uznalam ze to musi byc stan calej biblioteki --> ilosc donutow na stanie
{
    public class StateOfSHOP

    {
        //first int represents donut id and second quantity of avaible donuts
        private Dictionary<int, int> inventory = new Dictionary<int, int>();

        //lista donutow i ich ID zeby moc rozszyfrowac inventory 
        private Catalog catalog = new Catalog();


        public Dictionary<int, int> Inventory { get => inventory; set => inventory = value; }
    }
}
