using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.Menu
{
    public class MenuGetListByProfileQuery : IRequest<IEnumerable<Repository.Entities.Menu>>
    {
        public int profileId { get; set; }
    }
}
