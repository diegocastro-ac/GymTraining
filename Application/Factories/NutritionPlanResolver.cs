using Domain.Enums;

namespace Application.Factories
{
    public class NutritionPlanResolver
    {
        public NutritionPlanFactory Resolve(TrainingGoal goal)
        {
            return goal switch
            {
                TrainingGoal.Strength => new StrengthNutritionPlanFactory(),

                TrainingGoal.WeightLoss => new WeightLossNutritionPlanFactory(),

                _ => throw new ArgumentOutOfRangeException(nameof(goal), goal, "Nutrition plan not available for this training goal.")
            };
        }
    }
}