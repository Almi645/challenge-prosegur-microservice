using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Commands.Product
{
    public class ValidateStockProductCommandHandler : IRequestHandler<ValidateStockProductCommand, List<ValidateStockOutputProductCommand>>
    {
        readonly IUnitOfWork unitOfWork;

        public ValidateStockProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<ValidateStockOutputProductCommand>> Handle(ValidateStockProductCommand request, CancellationToken cancellationToken)
        {
            var outputList = new List<ValidateStockOutputProductCommand>();
            var productIdArray = request.products.Select(m => m.id).ToArray();
            var productDictionary = request.products.ToDictionary(k => k.id, v => v);
            var products = await unitOfWork.Repository<Repository.Entities.Product>().GetList(m => productIdArray.Contains(m.id));

            foreach (var item in products)
            {
                if ((item.stock - productDictionary[item.id].quantity) < 0)
                    outputList.Add(new ValidateStockOutputProductCommand { id = item.id, name = item.name });
            }

            return outputList;
        }
    }
}
