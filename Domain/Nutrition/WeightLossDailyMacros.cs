namespace Domain.Nutrition
{
    public class WeightLossDailyMacros : DailyMacros
    {
        public WeightLossDailyMacros()
            : base(1800, 160, 130, 60)
        {
        }

        public override string Describe()
        {
            return $"Daily macros (Weight Loss): {Calories} kcal, {Protein} g protein, {Carbs} g carbs, {Fat} g fat.";
        }
    }
}