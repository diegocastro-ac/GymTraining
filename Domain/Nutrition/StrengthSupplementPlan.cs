namespace Domain.Nutrition
{
    public class StrengthSupplementPlan : SupplementPlan
    {
        public StrengthSupplementPlan()
            : base(new List<Supplement>
            {
                new Supplement("Creatine Monohydrate", "5 g per day"),
                new Supplement("Whey Protein", "1 scoop after training"),
                new Supplement("Multivitamin", "1 tablet per day")
            })
        {
        }

        public override string Describe()
        {
            var supplements = string.Join(", ", Supplements.Select(supplement => $"{supplement.Name} ({supplement.DailyDose})"));

            return $"Supplements (Strength): {supplements}";
        }
    }
}