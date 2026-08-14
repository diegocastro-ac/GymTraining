using Domain.Enums;

namespace Domain.Entities
{
    public class Routine
    {
        private readonly List<Exercise> _exercises = new();

        public Guid Id { get; }
        public string Name { get; }
        public TrainingGoal TrainingGoal { get; }
        public IReadOnlyList<Exercise> Exercises => _exercises.AsReadOnly();

        public Routine(Guid id, string name, TrainingGoal trainingGoal)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Routine ID cannot be empty.", nameof(id));
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = id;
            Name = name;
            TrainingGoal = trainingGoal;
        }

        public void AddExercise(Exercise exercise)
        {
            ArgumentNullException.ThrowIfNull(exercise);

            _exercises.Add(exercise);
        }

        public string Execute()
        {
            var results = new List<string>();

            foreach (var exercise in _exercises)
            {
                results.Add(exercise.Execute());
            }

            return string.Join(Environment.NewLine, results);
        }
    }
}
