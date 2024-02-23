using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class ProfileAction : BaseEntity
    {
        public int profileId { get; set; }
        public int actionId { get; set; }
    }
}
