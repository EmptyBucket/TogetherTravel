using System.Linq;
using DataBase.Models.User;

namespace DataBase.Services
{
    public class UserDataService : IDataService<User>
    {
        private readonly TogetherTravelContext _context;

        public UserDataService(TogetherTravelContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll() => _context.Users;

        public string Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
    }
}