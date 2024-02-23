using Challenge.Repository.Base;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Invoice
{
    public class InvoiceGetListQueryHandler : IRequestHandler<InvoiceGetListQuery, IEnumerable<Repository.Entities.Invoice>>
    {
        private readonly IUnitOfWork unitOfWork;

        public InvoiceGetListQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Invoice>> Handle(InvoiceGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Invoice>().GetListInclude(m => m.province);
            return list;
        }
    }
}
