using FluentValidation;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be left blank.");
        }
    }
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be left blank.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be left blank.");
        }
    }
}
