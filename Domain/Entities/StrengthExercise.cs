using Domain.Enums;

namespace Domain.Entities
{
    public class StrengthExercise : Exercise
    {
        public int Sets { get; }
        public int Repetitions { get; }
        public decimal Weight { get; }

        public StrengthExercise(Guid id, string name, MuscleGroup muscleGroup, int sets, int repetitions, decimal weight)
            : base(id, name, muscleGroup)
        { 
            if (sets <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sets), "Sets must be greater than zero.");
            }

            if (repetitions <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repetitions), "Repetitions must be greater than zero.");
            }

            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be negative.");
            }

            Sets = sets;
            Repetitions = repetitions;
            Weight = weight;
        }

        public override string Execute()
        {
            return $"Performing {Name}: {Sets} sets x {Repetitions} repetitions with {Weight} kg.";
        }
    }
}
