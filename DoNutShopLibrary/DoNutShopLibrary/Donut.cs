using System;

namespace DoNutShopLibrary
{
    public class Donut
    {
        private String Name { get; set; }
        private int Id { get; set; }
        private double Price { get; set; }
        private FType Filling { get; set; }

        public Donut(string name, int id, double price, FType filling)
        {
            Name = name;
            Id = id;
            Price = price;
            Filling = filling;
           
        }

        public bool Equals(Donut other)
        {
            return this.Id== other.Id & this.Name == other.Name;
        }

        public enum FType
        {
            Vanilla,
            Chocolate,
            Caramel,
            Apple,
            Jelly,
            Strawberry,
            Lemon,
            Cinnamon
        }
    }
}
