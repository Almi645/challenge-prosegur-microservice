using Challenge.Application.Commands.Product;
using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Province
{
    public class ProvinceGetLisQueryHandler : IRequestHandler<ProvinceGetListQuery, IEnumerable<Repository.Entities.Province>>
    {
        readonly IUnitOfWork unitOfWork;

        public ProvinceGetLisQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Province>> Handle(ProvinceGetListQuery request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.Repository<Repository.Entities.Province>().GetList();
            return list;
        }
    }
}
