using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}
