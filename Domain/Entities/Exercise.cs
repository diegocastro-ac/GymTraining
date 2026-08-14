using Domain.Enums;

namespace Domain.Entities
{
    public abstract class Exercise
    {
        public Guid Id { get; }
        public string Name { get; }
        public MuscleGroup MuscleGroup { get; }

        protected Exercise(Guid id, string name, MuscleGroup muscleGroup)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Exercise ID cannot be empty.", nameof(id));
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = id;
            Name = name;
            MuscleGroup = muscleGroup;
        }

        public abstract string Execute();
    }
}
