using Domain.Entities;

namespace Application
{
    public class AppSession
    {
        public User? CurrentUser { get; private set; }

        public Routine? CurrentRoutine { get; private set; }

        public void SelectUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            CurrentUser = user;
            CurrentRoutine = null;
        }

        public void SelectRoutine(Routine routine)
        {
            ArgumentNullException.ThrowIfNull(routine);

            CurrentRoutine = routine;
        }

        public void ClearRoutine()
        {
            CurrentRoutine = null;
        }

        public void ClearUser()
        {
            CurrentUser = null;
            CurrentRoutine = null;
        }
    }
}
