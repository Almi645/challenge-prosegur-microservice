using Challenge.Application.Commands.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.Validations.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage($"Campo name requerido.");
            RuleFor(x => x.price).GreaterThan(default(decimal)).WithMessage($"Campo price debe ser mayor que 0.00");
        }
    }
}
