using FluentValidation;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure)
                                .NotEmpty().WithMessage("Name cannot be left blank.");
        }
    }
}
