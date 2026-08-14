using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services
{
    public class ExerciseService
    {
        private readonly IUserRepository _userRepository;

        public ExerciseService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Exercise? AddStrengthExercise(Guid userId, Guid routineId, string name, MuscleGroup muscleGroup,int sets, int repetitions, decimal weight)
        {
            var routine = FindRoutine(userId, routineId);

            if (routine is null)
            {
                return null;
            }

            var exercise = new StrengthExercise(Guid.NewGuid(), name, muscleGroup, sets, repetitions, weight);

            routine.AddExercise(exercise);

            return exercise;
        }

        public Exercise? AddCardioExercise(Guid userId, Guid routineId, string name, MuscleGroup muscleGroup, TimeSpan duration, decimal distance)
        {
            var routine = FindRoutine(userId, routineId);

            if (routine is null)
            {
                return null;
            }

            var exercise = new CardioExercise(Guid.NewGuid(), name, muscleGroup, duration, distance);

            routine.AddExercise(exercise);

            return exercise;
        }

        private Routine? FindRoutine(Guid userId, Guid routineId)
        {
            var user = _userRepository.GetById(userId);

            if (user is null)
            {
                return null;
            }

            return user.Routines.FirstOrDefault(routine => routine.Id == routineId);
        }
    }
}
