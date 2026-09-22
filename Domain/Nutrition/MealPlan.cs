namespace Domain.Nutrition
{
    public abstract class MealPlan
    {
        public IReadOnlyList<Meal> Meals { get; }

        protected MealPlan(IReadOnlyList<Meal> meals)
        {
            ArgumentNullException.ThrowIfNull(meals);

            Meals = meals;
        }

        public abstract string Describe();
    }
}