using Challenge.Application.Commands.OrderCommand;
using Challenge.Repository.Base;
using Challenge.Repository.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using System.Linq.Expressions;

namespace Challenge.Test.Application.Commands.OrderCommand
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly Mock<IDbContextTransaction> dbContextTransactionMock;
        private readonly CreateOrderCommandHandler createOrderCommandHandler;

        public CreateOrderCommandHandlerTest()
        {
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.dbContextTransactionMock = new Mock<IDbContextTransaction>();
            this.createOrderCommandHandler = new CreateOrderCommandHandler(unitOfWorkMock.Object);
        }

        [Fact]
        public async Task HandleTest()
        {
            var response = new List<Order>();

            unitOfWorkMock
                .Setup(r => r.Repository<Product>().GetList(It.IsAny<Expression<Func<Product, bool>>>(), new CancellationToken()))
                .ReturnsAsync(new List<Product>());

            unitOfWorkMock
                .Setup(r => r.Repository<Product>().GetByIds(It.IsAny<int[]>()))
                .ReturnsAsync(new List<Product>())
                .Verifiable();

            unitOfWorkMock
                .Setup(r => r.BeginTransactionAsync())
                .ReturnsAsync(dbContextTransactionMock.Object)
                .Verifiable();

            unitOfWorkMock
                .Setup(r => r.Repository<Order>().Add(It.IsAny<Order>()))
                .Verifiable();

            unitOfWorkMock
                .Setup(r => r.Repository<Product>().UpdateRange(It.IsAny<List<Product>>()))
                .Verifiable();

            unitOfWorkMock
                .Setup(r => r.SaveChangesAsync())
                .Verifiable();

            var createOrdeCommand = new CreateOrderCommand();
            createOrdeCommand.orderItems = new List<CreateOrderItemCommand>();

            var result = await createOrderCommandHandler.Handle(createOrdeCommand, new CancellationToken());

            Assert.True(result.Item1);
            Assert.Empty(result.Item2);
        }

        [Fact]
        public async Task HandleNoStockTest()
        {
            var response = new List<Order>();
        
            unitOfWorkMock
                .Setup(r => r.Repository<Product>().GetList(It.IsAny<Expression<Func<Product, bool>>>(), new CancellationToken()))
                .ReturnsAsync(GetListProductExpected());

            unitOfWorkMock
                .Setup(r => r.Repository<Product>().GetByIds(It.IsAny<int[]>()))
                .ReturnsAsync(GetListProductExpected())
                .Verifiable();

            var createOrdeCommand = new CreateOrderCommand();
            createOrdeCommand.orderItems = GetListCreateOrderItemCommandExpected();

            var result = await createOrderCommandHandler.Handle(createOrdeCommand, new CancellationToken());

            Assert.False(result.Item1);
            Assert.NotEmpty(result.Item2);
        }

        private List<Product> GetListProductExpected()
        {
            return new List<Product>()
            {
                new Product { id = 1, name = "Expreso Tradicional" },
                new Product { id = 2, name = "Expreso Flat White" }
            };
        }

        private List<CreateOrderItemCommand> GetListCreateOrderItemCommandExpected()
        {
            return new List<CreateOrderItemCommand>()
            {
                new CreateOrderItemCommand { productId = 1, price = 12, quantity = 1 },
                new CreateOrderItemCommand { productId = 2, price = 12, quantity = 1 }
            };
        }
    }
}
