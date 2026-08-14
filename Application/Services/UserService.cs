using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string name)
        {
            var user = new User(Guid.NewGuid(), name);
            _userRepository.Add(user);
            return user;
        }

        public User? GetUserById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public IReadOnlyCollection<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
