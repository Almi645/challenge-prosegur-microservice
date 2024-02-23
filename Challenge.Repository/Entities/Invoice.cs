using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Entities
{
    public class Invoice : BaseEntity
    {
        public int orderId { get; set; }
        public string serie { get; set; }
        public string document { get; set; }
        public DateTime date { get; set; }
        public int provinceId { get; set; }
        public decimal provinceTax { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        public List<InvoiceItem> invoiceItems { get; set; }
        public Order order { get; set; }
        public Province Province { get; set; }
    }
}
