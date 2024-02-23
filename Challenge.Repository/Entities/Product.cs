using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Product : BaseEntity
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}
