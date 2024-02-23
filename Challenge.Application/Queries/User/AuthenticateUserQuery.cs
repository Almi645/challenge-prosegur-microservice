using MediatR;
using System.Collections.Generic;

namespace Challenge.Application.Queries.User
{
    public class AuthenticateUserQuery : IRequest<AuthenticateUserViewModel>
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class AuthenticateUserViewModel
    {
        public string username { get; set; }
        public string fullname { get; set; }
        public int profileId { get; set; }
        public IEnumerable<Repository.Entities.Menu> menus { get; set; }
    }
}
