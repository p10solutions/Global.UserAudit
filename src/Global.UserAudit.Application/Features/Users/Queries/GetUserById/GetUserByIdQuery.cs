using Global.UserAudit.Application.Features.Common;
using MediatR;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : CommandBase<GetUserByIdQuery>, IRequest<GetUserByIdResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
            : base(new GetUserByIdQueryValidator())
        {
            Id = id;
        }
    }
}
