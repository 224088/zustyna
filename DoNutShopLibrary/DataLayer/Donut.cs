using DataLayer;
using System;

namespace DataLayer
{
    public  class Donut
    {
       
        public Donut(string Name, int Id, double Price, DonutTypeEnum Filling)
        {
            this.Name = Name;
            this.Id = Id;
            this.Price = Price;
            this.Filling = Filling;
           
        }

        public String Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }

        public DonutTypeEnum Filling { get; set; }


        public bool Equals(Donut other)
        {
            return this.Id== other.Id & this.Name == other.Name;
        }
    }
}
