using FluentValidation;
using Domain;

namespace Application.Validators
{
    public class ActivityValidator
    {
        public class RequiredFieldsValidator : AbstractValidator<Activity>
        {
            public RequiredFieldsValidator()
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
                RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
                RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
                RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
                RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
                RuleFor(x => x.Venue).NotEmpty().WithMessage("Venue is required.");
            }

            public bool IsValid(Activity activity)
            {
                if (this.Validate(activity).IsValid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public class NameOnlyValidator : AbstractValidator<Activity>
            {
                public NameOnlyValidator()
                {
                    RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
                }
            }

            public class FutureDateValidator : AbstractValidator<Activity>
            {
                public FutureDateValidator()
                {
                    RuleFor(x => x.Date)
                        .GreaterThan(DateTime.Now).WithMessage("Date must be in the future.");
                }
            }
        }
    }
}

