using System.Linq;
using DataBase.Models.User;

namespace DataBase.Services
{
    public class UserService
    {
        private readonly TogetherTravelContext _context;

        public UserService(TogetherTravelContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetUsers() => _context.Users;

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}