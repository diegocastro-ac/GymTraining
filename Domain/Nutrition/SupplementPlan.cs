namespace Domain.Nutrition
{
    public abstract class SupplementPlan
    {
        public IReadOnlyList<Supplement> Supplements { get; }

        protected SupplementPlan(IReadOnlyList<Supplement> supplements)
        {
            ArgumentNullException.ThrowIfNull(supplements);

            Supplements = supplements;
        }

        public abstract string Describe();
    }
}