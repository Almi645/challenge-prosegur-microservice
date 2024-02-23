using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.User
{
    public class AuthenticateUserQuery : IRequest<IEnumerable<Repository.Entities.Menu>>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
