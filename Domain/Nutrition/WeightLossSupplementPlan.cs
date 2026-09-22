namespace Domain.Nutrition
{
    public class WeightLossSupplementPlan : SupplementPlan
    {
        public WeightLossSupplementPlan()
            : base(new List<Supplement>
            {
                new Supplement("Omega-3", "2 g per day"),
                new Supplement("Multivitamin", "1 tablet per day"),
                new Supplement("Protein Snack", "1 bar per day")
            })
        {
        }

        public override string Describe()
        {
            var supplements = string.Join(", ", Supplements.Select(supplement => $"{supplement.Name} ({supplement.DailyDose})"));

            return $"Supplements (Weight Loss): {supplements}";
        }
    }
}