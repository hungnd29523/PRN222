using ProjectPRN.Models;

namespace ProjectPRN.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ImageSharingAppContext _context;

        public UserRepository(ImageSharingAppContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

}
