using Global.UserAudit.Application.Entities;

namespace Global.UserAudit.Application.Features.Users.Commands.UserChange
{
    public class UserChangeCommandMapper
    {
        public static User MapTo(UserChangeCommand command)
            => new(command.Name, command.DateBirth, command.Profile, command.ExternalId, command.ChangeType) { Active = command.Active};
    }
}
