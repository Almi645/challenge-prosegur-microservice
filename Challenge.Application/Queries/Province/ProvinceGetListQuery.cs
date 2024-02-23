using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Province
{
    public class ProvinceGetListQuery : IRequest<IEnumerable<Repository.Entities.Province>>
    {
    }
}
