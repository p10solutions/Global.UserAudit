namespace Global.UserAudit.Application.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public EProfile Profile { get; set; }
        public bool Active { get; set; }
        public EChangeType ChangeType { get; set; }
        public DateTime Date { get; set; }

        public User()
        {

        }

        public User(string name, DateTime dateBirth, EProfile profile, Guid externalId, EChangeType changeType)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateBirth = dateBirth;
            Profile = profile;
            Active = true;
            ExternalId = externalId;
            ChangeType = changeType;
            Date = DateTime.Now;
        }
    }
}
