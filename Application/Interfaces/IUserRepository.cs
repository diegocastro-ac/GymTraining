using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetById(Guid id);
        IReadOnlyCollection<User> GetAll();
    }
}
