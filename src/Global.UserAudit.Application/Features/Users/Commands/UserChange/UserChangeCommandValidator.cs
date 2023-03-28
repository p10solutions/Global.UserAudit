using FluentValidation;

namespace Global.UserAudit.Application.Features.Users.Commands.UserChange
{
    public class UserChangeCommandValidator : AbstractValidator<UserChangeCommand>
    {
        public UserChangeCommandValidator()
        {
            RuleFor(x => x.DateBirth).NotEmpty().WithMessage("DateBirth is required");
            RuleFor(x => x.ExternalId).NotEmpty().WithMessage("ExternalId is required");
            RuleFor(x => x.Profile).NotEmpty().WithMessage("Profile is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).Length(2, 200).WithMessage("Name only allows up to 200 characters");
        }
    }
}
