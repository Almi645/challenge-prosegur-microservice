using Challenge.Repository.Base;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Customer
{
    public class CustomerGetListQueryHandler : IRequestHandler<CustomerGetListQuery, IEnumerable<Repository.Entities.Customer>>
    {
        readonly IUnitOfWork unitOfWork;

        public CustomerGetListQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Customer>> Handle(CustomerGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Customer>().GetList();
            return list;
        }
    }
}
