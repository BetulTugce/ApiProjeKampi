using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Product name must be at least 2 characters long.");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Product name must be at most 50 characters long.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty.").GreaterThan(0).WithMessage("Price must be greater than zero.");
            //RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
        }
    }
}
