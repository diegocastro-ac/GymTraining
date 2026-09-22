namespace Domain.Nutrition
{
    public class WeightLossMealPlan : MealPlan
    {
        public WeightLossMealPlan()
            : base(new List<Meal>
            {
                new Meal("Egg White Omelette", 350),
                new Meal("Grilled Chicken Salad", 450),
                new Meal("Veggie Stir-Fry", 400),
                new Meal("Greek Yogurt", 180)
            })
        {
        }

        public override string Describe()
        {
            var meals = string.Join(", ", Meals.Select(meal => $"{meal.Name} ({meal.Calories} kcal)"));

            return $"Meal plan (Weight Loss): {meals}";
        }
    }
}