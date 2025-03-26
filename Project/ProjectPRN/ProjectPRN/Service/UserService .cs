using System.Security.Cryptography;
using System.Text;
using ProjectPRN.Models;
using ProjectPRN.Repository;

namespace ProjectPRN.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool RegisterUser(RegisterViewModel model)
        {
            if (_userRepository.GetUserByEmail(model.Email) != null)
            {
                return false; // Email đã tồn tại
            }

            var hashedPassword = HashPassword(model.Password);
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = hashedPassword
            };

            _userRepository.AddUser(user);
            return true;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || user.PasswordHash != HashPassword(password))
            {
                return null;
            }
            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
