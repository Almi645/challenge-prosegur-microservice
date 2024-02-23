using Challenge.Application.Base;
using Challenge.Common.Enums;
using Challenge.Common.Utility;
using Challenge.Repository.Base;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Commands.Invoice
{
    public class GeneratedInvoiceCommandHandler : IRequestHandler<GeneratedInvoiceCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public GeneratedInvoiceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(GeneratedInvoiceCommand request, CancellationToken cancellationToken)
        {
            var province = await unitOfWork.Repository<Repository.Entities.Province>().GetById(request.provinceId);

            var order = await unitOfWork.Repository<Repository.Entities.Order>().GetById(request.orderId, m => m.orderItems);
            order.stateCode = OrderStateEnum.INVOICED.GetValue();

            var invoice = new Repository.Entities.Invoice();
            invoice.serie = request.serie;
            invoice.document = request.document;
            invoice.provinceId = province.id;
            invoice.provinceTax = (province.tax / 100) * order.total;
            invoice.subTotal = order.total;
            invoice.total = ((province.tax / 100) * order.total) + order.total;
            invoice.date = DateTime.UtcNow;
            invoice.invoiceItems = order.orderItems.Select(m => new Repository.Entities.InvoiceItem
            {
                productId = m.productId,
                price = m.price,
                quantity = m.quantity,
                total = m.total
            }).ToList();

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    unitOfWork.Repository<Repository.Entities.Order>().Update(order);
                    await unitOfWork.Repository<Repository.Entities.Invoice>().Add(invoice);
                    await unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new CommonBaseException("Ocurrió un error inesperado.", e);
                }
            }

            return true;
        }
    }
}
