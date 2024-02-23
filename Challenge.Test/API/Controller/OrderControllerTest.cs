using Challenge.API.Controllers;
using Challenge.Application.Commands.OrderCommand;
using Challenge.Application.Queries.Order;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace Challenge.Test.API.Controller
{
    public class OrderControllerTest
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly OrderController orderController;

        public OrderControllerTest()
        {
            this.mediatorMock = new Mock<IMediator>();
            this.orderController = new OrderController(mediatorMock.Object);
        }

        [Fact]
        public async Task GetTest()
        {
            var query = It.IsAny<OrderGetListQuery>();
            var cancelationToken = new CancellationToken();
            var response = new List<Repository.Entities.Order>();
            mediatorMock.Setup(x => x.Send(query, cancelationToken)).ReturnsAsync(response);

            var current = await orderController.Get();

            ((ObjectResult)current).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)current).Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task PostTest()
        {
            var command = It.IsAny<CreateOrderCommand>();
            var cancelationToken = new CancellationToken();

            mediatorMock.Setup(x => x.Send(command, cancelationToken)).ReturnsAsync((true, new List<CreateOrderItemOuputCommand>()));

            var result = await orderController.Post(command);

            ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.OK);
            ((ObjectResult)result).Value.Should().BeEquivalentTo(true);
        }
    }
}
