namespace Domain.Nutrition
{
    public class NutritionPlan
    {
        public DailyMacros Macros { get; }
        public MealPlan MealPlan { get; }
        public SupplementPlan SupplementPlan { get; }

        public NutritionPlan(DailyMacros macros, MealPlan mealPlan, SupplementPlan supplementPlan)
        {
            ArgumentNullException.ThrowIfNull(macros);

            ArgumentNullException.ThrowIfNull(mealPlan);

            ArgumentNullException.ThrowIfNull(supplementPlan);

            Macros = macros;
            MealPlan = mealPlan;
            SupplementPlan = supplementPlan;
        }

        public string Execute()
        {
            var parts = new List<string>
            {
                Macros.Describe(),
                MealPlan.Describe(),
                SupplementPlan.Describe()
            };

            return string.Join(Environment.NewLine, parts);
        }
    }
}