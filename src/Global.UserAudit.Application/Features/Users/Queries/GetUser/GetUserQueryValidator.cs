using FluentValidation;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
        }
    }
}
