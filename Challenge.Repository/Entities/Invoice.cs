using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Repository.Entities
{
    public class Invoice : BaseEntity
    {
        public int orderId { get; set; }
        public string serie { get; set; }
        public string document { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("province")]
        public int provinceId { get; set; }
        public decimal provinceTax { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        public List<InvoiceItem> invoiceItems { get; set; }
        public Order order { get; set; }
        public Province province { get; set; }
    }
}
