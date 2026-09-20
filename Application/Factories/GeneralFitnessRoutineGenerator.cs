using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class GeneralFitnessRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.GeneralFitness);

            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Goblet Squat", MuscleGroup.Legs, 3, 10, 20));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Dumbbell Bench Press", MuscleGroup.Chest, 3, 10, 18));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Seated Cable Row", MuscleGroup.Back, 3, 10, 40));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Stationary Bike", MuscleGroup.Legs, TimeSpan.FromMinutes(20), 8));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Plank", MuscleGroup.Core, 3, 10, 20));

            return routine;
        }
    }
}