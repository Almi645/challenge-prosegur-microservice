using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Product
{
    public class ProductGetListQuery : IRequest<IEnumerable<Repository.Entities.Product>>
    {
    }
}
