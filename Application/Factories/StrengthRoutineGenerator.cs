using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class StrengthRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.Strength);

            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Bench Press", MuscleGroup.Chest, 5, 5, 90));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Squat", MuscleGroup.Legs, 5, 5, 120));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Deadlift", MuscleGroup.Back, 5, 3, 140));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Overhead Press", MuscleGroup.Shoulders, 4, 5, 50));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Barbell Row", MuscleGroup.Back, 4, 6, 60));

            return routine;
        }
    }
}