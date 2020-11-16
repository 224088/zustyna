using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataGeneration
{
    class FixedGenerator : IGenerator
    {

        public void GenarateData(DataContext data)
        {
            Donut d1 = new Donut("Toffee for your Coffee", 1, 8.9, DonutTypeEnum.Caramel);
            data.catalog.products.Add(1, d1);
            Donut d2 = new Donut("Jam-Packed", 2, 7.6, DonutTypeEnum.Jelly);
            data.catalog.products.Add(2, d2);
            Donut d3 = new Donut("I dream a Cream ", 3, 5.6, DonutTypeEnum.Vanilla);
            data.catalog.products.Add(3, d3);
            Donut d4 = new Donut("Big Apple", 4, 6.8, DonutTypeEnum.Apple);
            data.catalog.products.Add(3, d3);


            Customer c1 = new Customer("Ola", "Nowak", "O1");
            data.clients.Add(c1);
            Customer c2 = new Customer("Aleksandra", "Nowak", "A2");
            data.clients.Add(c2);
            Customer c3 = new Customer("Aleks", "Nowak", "A3");
            data.clients.Add(c3);

            data.shop.catalog = data.catalog;

            for (int i = 1; i <= data.catalog.products.Count; i++)
            {
                data.shop.inventory.Add(data.catalog.products[i].Id, 10);
            }

        }
    }
}
