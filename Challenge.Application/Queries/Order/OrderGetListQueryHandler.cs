using Challenge.Application.Commands.Product;
using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Order
{
    public class OrderGetListQueryHandler : IRequestHandler<OrderGetListQuery, IEnumerable<Repository.Entities.Order>>
    {
        readonly IUnitOfWork unitOfWork;

        public OrderGetListQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Order>> Handle(OrderGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Order>().GetListInclude(m => m.customer);
            return list;
        }
    }
}
