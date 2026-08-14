using Domain.Enums;

namespace Domain.Entities
{
    public class CardioExercise : Exercise
    {
        public TimeSpan Duration { get; }
        public decimal Distance { get; }

        public CardioExercise(Guid id, string name, MuscleGroup muscleGroup, TimeSpan duration, decimal distance)
            : base(id, name, muscleGroup)
        {
            if (duration == TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than zero.");
            }

            if (distance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distance), "Distance cannot be negative.");
            }

            Duration = duration;
            Distance = distance;
        }

        public override string Execute()
        {
            return $"Performing {Name}: {Duration.TotalMinutes} minutes for {Distance} km.";
        }
    }
}
