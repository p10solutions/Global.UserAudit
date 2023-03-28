using Global.UserAudit.Application.Contracts.Repositories;
using Global.UserAudit.Application.Entities;
using Global.UserAudit.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GlobalUserAudit.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<UserAuditDatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var mongoDataBase = client.GetDatabase(options.Value.DatabaseName);
            _userCollection = mongoDataBase.GetCollection<User>(
                options.Value.UserAuditCollectionName);
        }

        public async Task AddAsync(User user)
            => await _userCollection.InsertOneAsync(user);
        
        public async Task<IEnumerable<User>> GetAsync()
            => await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User> GetAsync(Guid id)
            => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(User user)
            => await _userCollection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }
}
