using Challenge.Application.Commands.OrderCommand;
using FluentValidation;

namespace Challenge.Application.Validations.OrderCommand
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.customerId).GreaterThan(0).WithMessage($"Campo customerId requerido.");
        }
    }
}
