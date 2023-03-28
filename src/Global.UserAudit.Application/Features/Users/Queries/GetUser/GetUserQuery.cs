using Global.UserAudit.Application.Features.Common;
using MediatR;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : CommandBase<GetUserQuery>, IRequest<IEnumerable<GetUserResponse>>
    {
        public GetUserQuery()
            : base(new GetUserQueryValidator())
        {
        }
    }
}
