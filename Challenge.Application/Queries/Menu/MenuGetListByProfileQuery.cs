using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Menu
{
    public class MenuGetListByProfileQuery : IRequest<IEnumerable<Repository.Entities.Menu>>
    {
        public int profileId { get; set; }
    }
}
