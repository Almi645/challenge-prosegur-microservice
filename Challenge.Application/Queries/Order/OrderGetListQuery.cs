using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Order
{
    public class OrderGetListQuery : IRequest<IEnumerable<Repository.Entities.Order>>
    {
    }
}
