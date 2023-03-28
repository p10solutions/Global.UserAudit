using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Features.Users.Commands.UserChange;

namespace Global.UserAudit.Application.Models.Events.Users.Maps
{
    public static class UserUpdatedMapper
    {
        public static UserChangeCommand MapTo(UserUpdatedEvent userUpdated, EChangeType changeType)
            => new(userUpdated.Name, userUpdated.DateBirth, userUpdated.Profile, userUpdated.Id, userUpdated.Active, changeType);
    }
}
