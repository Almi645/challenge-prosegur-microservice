using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Action : BaseEntity
    {
        public int menuId { get; set; }
        public string name { get; set; }
    }
}
