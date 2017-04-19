using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;
using DataBase.Services;
using Microsoft.AspNet.Identity.Owin;

namespace TogetherTravel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() => View();

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetUsers()
        {
            var context = HttpContext.GetOwinContext().Get<TogetherTravelContext>();
            var userService = new UserService(context);
            var users = userService.GetUsers()
                .Select(user => new
                {
                    user.FirstName,
                    user.SecondName,
                    user.LatitudeCoord,
                    user.LongitudeCoord
                });
            return Json(users);
        }
    }
}