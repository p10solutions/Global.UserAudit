using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Features.Users.Commands.UserChange;

namespace Global.UserAudit.Application.Models.Events.Users.Maps
{
    public static class UserInsertedMapper
    {
        public static UserChangeCommand MapTo(UserInsertedEvent userInsertedEvent)
            => new(userInsertedEvent.Name, userInsertedEvent.DateBirth, userInsertedEvent.Profile,
                userInsertedEvent.Id, userInsertedEvent.Active, EChangeType.Insert);
    }
}
