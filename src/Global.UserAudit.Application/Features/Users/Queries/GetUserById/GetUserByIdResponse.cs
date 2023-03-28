using Global.UserAudit.Application.Entities;

namespace Global.UserAudit.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdResponse
    {
        public Guid Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public EProfile Profile { get; set; }
        public EChangeType ChangeType { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public GetUserByIdResponse(Guid id, string name, DateTime dateBirth, EProfile profile,
            bool active, Guid externalId, EChangeType changeType, DateTime date)
        {
            Id = id;
            Name = name;
            DateBirth = dateBirth;
            Profile = profile;
            Active = active;
            ExternalId = externalId;
            ChangeType = changeType;
            Date = date;
        }
    }
}
