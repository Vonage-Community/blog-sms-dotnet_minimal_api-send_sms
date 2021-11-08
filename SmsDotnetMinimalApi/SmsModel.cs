using FluentValidation;

namespace SmsDotnetMinimalApi
{
public class SmsModel
{
    public string To { get; set; }
    public string From { get; set; }
    public string Text { get; set; }

    public class Validator : AbstractValidator<SmsModel>
    {
        public Validator()
        {
            RuleFor(x => x.To).NotEmpty().WithMessage("To phone number required");
            RuleFor(x => x.From).NotEmpty().WithMessage("From phone number required");
        }
    }
}
}
