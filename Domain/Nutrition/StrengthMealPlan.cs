namespace Domain.Nutrition
{
    public class StrengthMealPlan : MealPlan
    {
        public StrengthMealPlan()
            : base(new List<Meal>
            {
                new Meal("High Protein Oats", 500),
                new Meal("Chicken & Rice", 750),
                new Meal("Beef Burrito Bowl", 800),
                new Meal("Whey Protein Shake", 250)
            })
        {
        }

        public override string Describe()
        {
            var meals = string.Join(", ", Meals.Select(meal => $"{meal.Name} ({meal.Calories} kcal)"));

            return $"Meal plan (Strength): {meals}";
        }
    }
}