using Cdb.App.Requests;
using FluentValidation;

namespace CdbApp.Validators
{
    public class CdbRequestValidator : AbstractValidator<CdbRequest>
    {
        public CdbRequestValidator()
        {
            RuleFor(x => x.InitialAmount)                
                .GreaterThan(0).WithMessage("The 'initialAmount' property must be grater than 0.");

            RuleFor(x => x.Months)
                .GreaterThan(1).WithMessage("The 'months' property must be at least 2.");
        }
    }
}
