using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
     public class Customer
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Id { get; set; }

        public Customer(String FirstName, String LastName, String Id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;

        }

        public override bool Equals(object obj)
        {
            Customer other = (Customer)obj;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 1258739292;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}
