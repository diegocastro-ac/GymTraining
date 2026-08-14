namespace Domain.Entities
{
    public class User
    {
        private readonly List<Routine> _routines = new();

        public Guid Id { get; }
        public string Name { get; }
        public IReadOnlyCollection<Routine> Routines => _routines.AsReadOnly();

        public User(Guid id, string name)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("User ID cannot be empty.", nameof(id));
            }

            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = id;
            Name = name;
        }

        public void AddRoutine(Routine routine)
        {
            ArgumentNullException.ThrowIfNull(routine);

            _routines.Add(routine);
        }
    }
}
