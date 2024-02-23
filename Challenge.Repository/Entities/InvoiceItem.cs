using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public int productId { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
    }
}
