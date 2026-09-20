using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class EnduranceRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.Endurance);

            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Push-Ups", MuscleGroup.Chest, 3, 20, 15));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Air Squats", MuscleGroup.Legs, 3, 25, 15));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Plank", MuscleGroup.Core, 3, 10, 15));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Treadmill Run", MuscleGroup.Legs, TimeSpan.FromMinutes(30), 5));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Rowing", MuscleGroup.Back, TimeSpan.FromMinutes(20), 4));

            return routine;
        }
    }
}