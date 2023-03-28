using Global.UserAudit.Application.Entities;

namespace Global.UserAudit.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAsync();
    }
}
