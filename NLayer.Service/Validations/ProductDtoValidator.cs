using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name).Cascade(cascadeMode: CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Price)
                .ExclusiveBetween(0, decimal.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.Stock)
                .ExclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
        }
    }

    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            //Include(new ProductDtoValidator());
        }
    }
}
