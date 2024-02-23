using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Menu : BaseEntity
    {
        public string name { get; set; }
        public string url { get; set; }
        public List<Action> actions { get; set; }
    }
}
