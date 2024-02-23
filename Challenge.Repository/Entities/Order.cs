using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey("customer")]
        public int cutomerId { get; set; }
        public string stateCode { get; set; }
        public decimal total { get; set; }
        public DateTime date { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public Customer customer { get; set; }
    }
}
