using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Customer
{
    public class CustomerGetListQuery : IRequest<IEnumerable<Repository.Entities.Customer>>
    {
    }
}
