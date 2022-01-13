using Domain.Models;
using FluentValidation;

namespace Application.Validation
{
    public class ActivityValidation : AbstractValidator<Activity>
    {
        public ActivityValidation()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
            RuleFor(x => x.City).NotEmpty();

            RuleFor(x => x.Category).NotEmpty()
                .Must(categoty => ActivityCategories.CategoriesList().Contains(categoty))
                .WithMessage(x => $"'{x.Category}' category does not exist. Consider using one of these ones: {string.Join(", " , ActivityCategories.CategoriesList())}")
                .When(x => x.Category != null, ApplyConditionTo.CurrentValidator);
        }
    }
}