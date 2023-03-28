using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Features.Common;
using MediatR;

namespace Global.UserAudit.Application.Features.Users.Commands.UserChange
{
    public class UserChangeCommand : CommandBase<UserChangeCommand>, IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid ExternalId { get; set; }
        public DateTime DateBirth { get; set; }
        public EProfile Profile { get; set; }
        public bool Active { get; set; }
        public EChangeType ChangeType { get; set; }

        public UserChangeCommand(string name, DateTime dateBirth, EProfile profile, Guid externalId, bool active, EChangeType changeType)
            : base(new UserChangeCommandValidator())
        {
            Name = name;
            DateBirth = dateBirth;
            Profile = profile;
            ExternalId = externalId;
            Active = active;
            ChangeType = changeType;
        }
    }
}
