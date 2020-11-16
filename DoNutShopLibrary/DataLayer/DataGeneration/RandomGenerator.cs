using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataGeneration
{
    public class RandomGenerator : IGenerator
    {

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public DonutTypeEnum randomDonutType()
        {
            Array values = Enum.GetValues(typeof(DonutTypeEnum));
            DonutTypeEnum randomDonutType = (DonutTypeEnum)values.GetValue(random.Next(values.Length));
            return randomDonutType;
        }

        public double randomPrice(double minimum, double maximum)
        {
            return random.NextDouble() *(maximum - minimum) + minimum;
        }

        public void GenarateData(DataContext data)
        {


            for (int i = 1; i <= 9; i++)
            {
               
               
                Donut donut = new Donut(GenerateRandomString(25),
                    i, randomPrice(5.00, 15.90), randomDonutType());
                data.catalog.products.Add(i, donut);

                Customer customer = new Customer(GenerateRandomString(6), GenerateRandomString(13), i.ToString());
                data.clients.Add(customer);
            }

        }
    }
}
