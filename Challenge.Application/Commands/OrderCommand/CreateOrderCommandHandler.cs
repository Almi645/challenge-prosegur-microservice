using Challenge.Application.Commands.Product;
using Challenge.Repository.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Challenge.Repository.Entities;
using Challenge.Application.Base;
using Challenge.Common.Enums;
using Challenge.Common.Utility;

namespace Challenge.Application.Commands.OrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, (bool, List<CreateOrderItemOuputCommand>)>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public CreateOrderCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        public async Task<(bool, List<CreateOrderItemOuputCommand>)> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            #region Validate Stock

            var group = request.orderItems.GroupBy(m => new { m.productId, m.price });
            request.orderItems = new List<CreateOrderItemCommand>();

            foreach (var item in group)
            {
                request.orderItems.Add(new CreateOrderItemCommand
                {
                    productId = item.Key.productId,
                    price = item.Key.price,
                    quantity = item.Sum(m => m.quantity)
                });
            }


            var productNotAvailableList = new List<CreateOrderItemOuputCommand>();
            var productIdStockArray = request.orderItems.Select(m => m.productId).ToArray();
            var productStockDictionary = request.orderItems.ToDictionary(k => k.productId, v => v);
            var productStockList = await unitOfWork.Repository<Repository.Entities.Product>().GetList(m => productIdStockArray.Contains(m.id));

            foreach (var item in productStockList)
            {
                if ((item.stock - productStockDictionary[item.id].quantity) < 0)
                    productNotAvailableList.Add(new CreateOrderItemOuputCommand { id = item.id, name = item.name });
            }

            if (productNotAvailableList.Any())
            {
                return (false, productNotAvailableList);
            }

            #endregion

            #region Set Stock

            var productIdArray = request.orderItems.Select(m => m.productId).ToArray();
            var productDictionary = request.orderItems.ToDictionary(k => k.productId, v => v);
            var products = await unitOfWork.Repository<Repository.Entities.Product>().GetByIds(productIdArray);

            foreach (var item in products)
                item.stock -= productDictionary[item.id].quantity;

            #endregion

            #region Map Entity

            var order = new Order
            {
                cutomerId = request.customerId,
                stateCode = OrderStateEnum.PENDING.GetValue(),
                date = DateTime.Now,
                orderItems = new List<OrderItem>()
            };

            var productDictionaryDb = products.ToDictionary(k => k.id, v => v);

            foreach (var item in request.orderItems)
            {
                var orderItem = new OrderItem();
                orderItem.id = item.productId;
                orderItem.price = productDictionaryDb[item.productId].price;
                orderItem.quantity = item.quantity;
                orderItem.total = item.quantity * orderItem.price;
                order.orderItems.Add(orderItem);
            }

            order.total = order.orderItems.Sum(m => m.total);

            #endregion

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await unitOfWork.Repository<Repository.Entities.Order>().Add(order);
                    unitOfWork.Repository<Repository.Entities.Product>().UpdateRange(products);
                    await unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new CommonBaseException("Ocurrió un error inesperado.", e);
                }
            }

            return (true, new List<CreateOrderItemOuputCommand>());
        }
    }
}
