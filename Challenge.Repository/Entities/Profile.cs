using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Profile : BaseEntity
    {
        public string name { get; set; }
        public List<ProfileAction> profileActions { get; set; }
    }
}
