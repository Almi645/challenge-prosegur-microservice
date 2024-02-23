using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.User
{
    public class AuthenticateUserQuery : IRequest<IEnumerable<Repository.Entities.Menu>>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
