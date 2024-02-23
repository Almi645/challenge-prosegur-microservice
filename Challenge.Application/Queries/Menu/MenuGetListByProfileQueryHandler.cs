using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Queries.Menu
{
    public class MenuGetListByProfileQueryHandler : IRequestHandler<MenuGetListByProfileQuery, IEnumerable<Repository.Entities.Menu>>
    {
        private readonly IUnitOfWork unitOfWork;

        public MenuGetListByProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Repository.Entities.Menu>> Handle(MenuGetListByProfileQuery request, CancellationToken cancellationToken)
        {
            var profileActions = await unitOfWork.Repository<Repository.Entities.ProfileAction>().GetList(m => m.profileId == request.profileId);
            var actionIdArray = profileActions.Select(x => x.actionId).ToArray();
            var list = await unitOfWork.Repository<Repository.Entities.Menu>().GetListInclude(m => m.actions.Any(x => actionIdArray.Contains(x.id)), m => m.actions);
            
            foreach ( var menu in list)
                menu.actions = menu.actions.Where(m => actionIdArray.Contains(m.id)).ToList();

            return list;
        }
    }
}
