using Challenge.Application.Commands.Product;
using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Product
{
    public class ProductGetListQueryHandler : IRequestHandler<ProductGetListQuery, IEnumerable<Repository.Entities.Product>>
    {
        readonly IUnitOfWork unitOfWork;

        public ProductGetListQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Product>> Handle(ProductGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Product>().GetList();
            return list;
        }
    }
}
