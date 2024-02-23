using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Commands.OrderCommand
{
    public class CreateOrderCommand : IRequest<(bool, List<CreateOrderItemOuputCommand>)>
    {
        public int customerId { get; set; }
        public List<CreateOrderItemCommand> orderItems { get; set; }
    }

    public class CreateOrderItemCommand
    {
        public int productId { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }

    public class CreateOrderItemOuputCommand
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
