namespace Domain.Nutrition
{
    public class StrengthDailyMacros : DailyMacros
    {
        public StrengthDailyMacros()
            : base(2800, 180, 350, 70)
        {
        }

        public override string Describe()
        {
            return $"Daily macros (Strength): {Calories} kcal, {Protein} g protein, {Carbs} g carbs, {Fat} g fat.";
        }
    }
}