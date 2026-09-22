namespace Domain.Nutrition
{
    public class Meal
    {
        public string Name { get; }
        public int Calories { get; }

        public Meal(string name, int calories)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            if (calories <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calories), "Calories must be greater than zero.");
            }

            Name = name;
            Calories = calories;
        }
    }
}