using FluentValidation;

namespace Oiga.Bussines.Model.Validations
{
    public class EvaluationValidation : AbstractValidator<Evaluation>
    {
        public EvaluationValidation()
        {
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Field {PropertyName} needs to be provided");

            RuleFor(e => e.Stars)
                .InclusiveBetween(1, 5)
                .WithMessage("Field {PropertyName} need to be between 1 and 5 ");
        }
    }
}
