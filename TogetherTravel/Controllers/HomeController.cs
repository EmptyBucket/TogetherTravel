using System.Linq;
using System.Web.Mvc;
using DataBase;
using DataBase.Services;

namespace TogetherTravel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        [HttpPost]
        public ActionResult GetUsers()
        {
            using (var togetherTravelContext = new TogetherTravelContext())
            {
                var userService = new UserService(togetherTravelContext);
                var users = userService.GetUsers().ToArray();
                return Json(users);
            }
        }
    }
}