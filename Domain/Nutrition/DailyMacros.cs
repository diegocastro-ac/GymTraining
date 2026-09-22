namespace Domain.Nutrition
{
    public abstract class DailyMacros
    {
        public double Calories { get; }
        public double Protein { get; }
        public double Carbs { get; }
        public double Fat { get; }

        protected DailyMacros(double calories, double protein, double carbs, double fat)
        {
            if (calories <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calories), "Calories must be greater than zero.");
            }

            if (protein <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(protein), "Protein must be greater than zero.");
            }

            if (carbs <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(carbs), "Carbs must be greater than zero.");
            }

            if (fat <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fat), "Fat must be greater than zero.");
            }

            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;
        }

        public abstract string Describe();
    }
}