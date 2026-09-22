using Domain.Nutrition;

namespace Application.Factories
{
    public abstract class NutritionPlanFactory
    {
        public abstract DailyMacros CreateDailyMacros();

        public abstract MealPlan CreateMealPlan();

        public abstract SupplementPlan CreateSupplementPlan();

        public NutritionPlan CreatePlan()
        {
            return new NutritionPlan(CreateDailyMacros(), CreateMealPlan(), CreateSupplementPlan());
        }
    }
}