using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Commands.Product
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}
