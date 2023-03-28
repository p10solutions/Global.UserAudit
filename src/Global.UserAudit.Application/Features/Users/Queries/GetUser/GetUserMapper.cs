using Global.UserAudit.Application.Entities;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUser
{
    public class GetUserMapper
    {
        public static GetUserResponse MapFrom(User user)
            => new(user.Id, user.Name, user.DateBirth, user.Profile, user.Active, user.ExternalId, user.ChangeType, user.Date);

        public static IEnumerable<GetUserResponse> MapFrom(IEnumerable<User> taskItems)
            => taskItems.Select(x => MapFrom(x));
    }
}
