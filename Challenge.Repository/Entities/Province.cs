using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Province : BaseEntity
    {
        public string name { get; set; }
        public decimal tax { get; set; }
    }
}
