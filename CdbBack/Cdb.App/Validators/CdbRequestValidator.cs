using Cdb.App.Requests;
using FluentValidation;

namespace CdbApp.Validators
{
    public class CdbRequestValidator : AbstractValidator<CdbRequest>
    {
        public CdbRequestValidator()
        {
            RuleFor(x => x.Value)                
                .GreaterThan(0).WithMessage("The 'value' property must be grater than 0.");

            RuleFor(x => x.Months)
                .GreaterThan(0).WithMessage("The 'months' property must be at least 1.");
        }
    }
}
