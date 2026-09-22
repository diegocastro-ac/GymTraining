namespace Domain.Nutrition
{
    public class Supplement
    {
        public string Name { get; }
        public string DailyDose { get; }

        public Supplement(string name, string dailyDose)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            ArgumentException.ThrowIfNullOrWhiteSpace(dailyDose);

            Name = name;
            DailyDose = dailyDose;
        }
    }
}