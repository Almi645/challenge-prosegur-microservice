using Challenge.Application.Base;
using Challenge.Application.Queries.Menu;
using Challenge.Repository.Base;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.User
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, AuthenticateUserViewModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public AuthenticateUserQueryHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        public async Task<AuthenticateUserViewModel> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var userList = await unitOfWork.Repository<Repository.Entities.User>().GetList(m => m.username == request.username && m.password == request.password);
            var user = userList.FirstOrDefault();

            if (user == null)
            {
                throw new CommonBaseException("Usuario y/o contraseña erroneos.");
            }

            var queryFilter = new MenuGetListByProfileQuery();
            queryFilter.profileId = user.profileId;
            var menus = await mediator.Send(queryFilter);

            var result = new AuthenticateUserViewModel
            {
                username = user.username,
                fullname = user.fullname,
                profileId = user.profileId,
                menus = menus
            };

            return result;
        }
    }
}
