using System.Linq;
using System.Web.Mvc;
using DataBase.Models.User;
using DataBase.Services;

namespace TogetherTravel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDataService<User> _userDataService;

        public HomeController(IDataService<User> userDataService)
        {
            _userDataService = userDataService;
        }

        [AllowAnonymous]
        public ActionResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetUsers()
        {
            var users = _userDataService.GetAll()
                .Select(user => new
                {
                    user.Id,
                    user.FirstName,
                    user.SecondName,
                    user.LatitudeCoord,
                    user.LongitudeCoord
                });
            return Json(users);
        }
    }
}