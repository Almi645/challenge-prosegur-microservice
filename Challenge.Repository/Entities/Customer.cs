using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Customer : BaseEntity
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
    }
}
