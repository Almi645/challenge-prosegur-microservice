using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Invoice
{
    public class InvoiceGetListQueryHandler : IRequestHandler<InvoiceGetListQuery, IEnumerable<Repository.Entities.Invoice>>
    {
        readonly IUnitOfWork unitOfWork;

        public InvoiceGetListQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Invoice>> Handle(InvoiceGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Invoice>().GetListInclude(m => m.invoiceItems);
            return list;
        }
    }
}
