using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Province
{
    public class ProvinceGetListQuery : IRequest<IEnumerable<Repository.Entities.Province>>
    {
    }
}
