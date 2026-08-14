using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetById(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
        
        public IReadOnlyCollection<User> GetAll()
        {
            return _users.AsReadOnly();
        }
    }
}
