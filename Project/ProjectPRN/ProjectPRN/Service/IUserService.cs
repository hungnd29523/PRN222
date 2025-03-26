using ProjectPRN.Models;

namespace ProjectPRN.Service
{
    public interface IUserService
    {
        User AuthenticateUser(string email, string password);
        bool RegisterUser(RegisterViewModel model);
    }
}
