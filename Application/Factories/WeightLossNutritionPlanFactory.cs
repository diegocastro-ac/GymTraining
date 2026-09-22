using Domain.Nutrition;

namespace Application.Factories
{
    public class WeightLossNutritionPlanFactory : NutritionPlanFactory
    {
        public override DailyMacros CreateDailyMacros()
        {
            return new WeightLossDailyMacros();
        }

        public override MealPlan CreateMealPlan()
        {
            return new WeightLossMealPlan();
        }

        public override SupplementPlan CreateSupplementPlan()
        {
            return new WeightLossSupplementPlan();
        }
    }
}