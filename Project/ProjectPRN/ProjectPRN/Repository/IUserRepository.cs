using ProjectPRN.Models;

namespace ProjectPRN.Repository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        void AddUser(User user);
    }

}
