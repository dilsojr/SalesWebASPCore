using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SalesWebMvcASPCore.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        { 
        }

        public Department(string name)
        {
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime dateInitial, DateTime dateFinal)
        {
            return Sellers.Sum(sl => sl.TotalSales(dateInitial, dateFinal));
        }
    }
}
