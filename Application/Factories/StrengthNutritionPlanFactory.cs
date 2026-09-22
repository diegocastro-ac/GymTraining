using Domain.Nutrition;

namespace Application.Factories
{
    public class StrengthNutritionPlanFactory : NutritionPlanFactory
    {
        public override DailyMacros CreateDailyMacros()
        {
            return new StrengthDailyMacros();
        }

        public override MealPlan CreateMealPlan()
        {
            return new StrengthMealPlan();
        }

        public override SupplementPlan CreateSupplementPlan()
        {
            return new StrengthSupplementPlan();
        }
    }
}