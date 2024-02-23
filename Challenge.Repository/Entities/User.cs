using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public int profileId { get; set; }
    }
}
