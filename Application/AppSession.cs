using Domain.Entities;

namespace Application
{
    public class AppSession
    {
        public User? CurrentUser { get; private set; }

        public void SelectUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            CurrentUser = user;
        }

        public void ClearUser()
        {
            CurrentUser = null;
        }
    }
}
