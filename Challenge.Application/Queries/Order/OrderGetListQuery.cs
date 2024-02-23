using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Order
{
    public class OrderGetListQuery : IRequest<IEnumerable<Repository.Entities.Order>>
    {
    }
}
