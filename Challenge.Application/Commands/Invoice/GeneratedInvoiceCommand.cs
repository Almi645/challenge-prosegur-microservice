using MediatR;

namespace Challenge.Application.Commands.Invoice
{
    public class GeneratedInvoiceCommand : IRequest<bool>
    {
        public string serie { get; set; }
        public string document { get; set; }
        public int provinceId { get; set; }
        public int orderId { get; set; }
    }
}
