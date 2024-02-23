using Challenge.Repository.Base;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Province
{
    public class ProvinceGetListQueryHandler : IRequestHandler<ProvinceGetListQuery, IEnumerable<Repository.Entities.Province>>
    {
        private readonly IUnitOfWork unitOfWork;

        public ProvinceGetListQueryHandler(IUnitOfWork unitOfWork)
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
