using Domain.Entities;

namespace Application.Factories
{
    public abstract class RoutineGenerator
    {
        public Routine Generate(User user, string name)
        {
            ArgumentNullException.ThrowIfNull(user);

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            var routine = CreateRoutine(name);

            user.AddRoutine(routine);

            return routine;
        }

        protected abstract Routine CreateRoutine(string name);
    }
}