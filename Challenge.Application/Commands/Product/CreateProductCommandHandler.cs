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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        readonly IUnitOfWork unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Repository.Entities.Product();
            product.name = request.name;
            product.price = request.price;
            product.stock = request.stock;

            await unitOfWork.Repository<Repository.Entities.Product>().Add(product);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
