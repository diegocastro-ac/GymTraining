using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class WeightLossRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.WeightLoss);

            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Treadmill Incline Walk", MuscleGroup.Legs, TimeSpan.FromMinutes(30), 4));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Elliptical", MuscleGroup.Legs, TimeSpan.FromMinutes(20), 6));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Rowing Machine", MuscleGroup.Back, TimeSpan.FromMinutes(15), 3));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Kettlebell Swing", MuscleGroup.Legs, 4, 15, 16));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Mountain Climbers", MuscleGroup.Core, 3, 20, 12));

            return routine;
        }
    }
}