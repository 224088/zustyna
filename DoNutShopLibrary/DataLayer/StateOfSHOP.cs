using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer


    //Dobra po doczytaniu instrukcji uznalam ze to musi byc stan calej biblioteki --> ilosc donutow na stanie
{
    public class StateOfSHOP

    {
        //first int represents donut id and second quantity of avaible donuts
        public Dictionary<int, int> inventory { get; set; } = new Dictionary<int, int>();

        //lista donutow i ich ID zeby moc rozszyfrowac inventory 
        public Catalog catalog { get; set; } = new Catalog();


        
    }
}
