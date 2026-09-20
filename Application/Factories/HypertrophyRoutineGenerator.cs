using Domain.Entities;
using Domain.Enums;

namespace Application.Factories
{
    public class HypertrophyRoutineGenerator : RoutineGenerator
    {
        protected override Routine CreateRoutine(string name)
        {
            var routine = new Routine(Guid.NewGuid(), name, TrainingGoal.Hypertrophy);

            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Incline Dumbbell Press", MuscleGroup.Chest, 4, 10, 24));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Lat Pulldown", MuscleGroup.Back, 4, 12, 55));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Leg Press", MuscleGroup.Legs, 4, 10, 160));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Lateral Raise", MuscleGroup.Shoulders, 3, 12, 10));
            routine.AddExercise(new StrengthExercise(Guid.NewGuid(), "Bicep Curl", MuscleGroup.Arms, 3, 10, 12));

            return routine;
        }
    }
}