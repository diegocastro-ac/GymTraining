using Domain.Enums;

namespace Application.Factories
{
    public class RoutineGeneratorResolver
    {
        public RoutineGenerator Resolve(TrainingGoal goal)
        {
            return goal switch
            {
                TrainingGoal.Strength => new StrengthRoutineGenerator(),

                TrainingGoal.Hypertrophy => new HypertrophyRoutineGenerator(),

                TrainingGoal.Endurance => new EnduranceRoutineGenerator(),

                TrainingGoal.GeneralFitness => new GeneralFitnessRoutineGenerator(),

                TrainingGoal.MuscleGain => new MuscleGainRoutineGenerator(),

                TrainingGoal.WeightLoss => new WeightLossRoutineGenerator(),

                _ => throw new ArgumentOutOfRangeException(nameof(goal), goal, "Unsupported training goal.")
            };
        }
    }
}