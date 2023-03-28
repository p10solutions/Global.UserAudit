using Global.UserAudit.Application.Entities;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdMapper
    {
        public static GetUserByIdResponse MapFrom(User user)
            => new(user.Id, user.Name, user.DateBirth, user.Profile, user.Active, user.ExternalId, user.ChangeType, user.Date);
    }
}
