using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class MuscleGainRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.MuscleGain);

            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Barbell Squat", MuscleGroup.Legs, 4, 8, 100));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Flat Bench Press", MuscleGroup.Chest, 4, 8, 80));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Romanian Deadlift", MuscleGroup.Back, 4, 10, 70));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Military Press", MuscleGroup.Shoulders, 4, 8, 45));
            routine.AddExercise(new CardioExercise(Guid.NewGuid(), "Light Walk", MuscleGroup.Legs, TimeSpan.FromMinutes(15), 3));

            return routine;
        }
    }
}