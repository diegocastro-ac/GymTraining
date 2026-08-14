using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services
{
    public class RoutineService
    {
        private readonly IUserRepository _userRepository;

        public RoutineService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Routine? CreateRoutine(Guid userId, string name, TrainingGoal goal)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                return null;
            }

            var routine = new Routine(Guid.NewGuid(), name, goal);

            user.AddRoutine(routine);

            return routine;
        }
    }
}
