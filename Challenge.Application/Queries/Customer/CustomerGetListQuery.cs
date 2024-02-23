using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Customer
{
    public class CustomerGetListQuery : IRequest<IEnumerable<Repository.Entities.Customer>>
    {
    }
}
