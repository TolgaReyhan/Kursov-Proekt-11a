using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Withdraw { get; set; }
        public double Deposit { get; set; }
    }
}
