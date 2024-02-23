using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Invoice
{
    public class InvoiceGetListQuery : IRequest<IEnumerable<Repository.Entities.Invoice>>
    {
    }
}
