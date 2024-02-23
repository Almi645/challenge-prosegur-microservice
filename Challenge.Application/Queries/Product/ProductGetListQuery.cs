using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Product
{
    public class ProductGetListQuery : IRequest<IEnumerable<Repository.Entities.Product>>
    {
    }
}
