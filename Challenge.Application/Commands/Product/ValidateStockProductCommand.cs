using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Commands.Product
{
    public class ValidateStockProductCommand : IRequest<List<ValidateStockOutputProductCommand>>
    {
        public List<ValidateStockInputProductCommand> products { get; set; }
    }

    public class ValidateStockInputProductCommand
    {
        public int id { get; set; }
        public int quantity { get; set; }
    }

    public class ValidateStockOutputProductCommand
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
