using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataBase.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TogetherTravel.ViewModels;

namespace TogetherTravel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        private ApplicationUserManager _userManager;

        private ApplicationSignInManager _signInManager;

        private ApplicationRoleManager _roleManager;

        private IAuthenticationManager _autenticationManaber;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ApplicationSignInManager SignInManager => _signInManager ?? 
            (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());

        public ApplicationUserManager UserManager => _userManager ?? 
            (_userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>());

        public ApplicationRoleManager RoleManager => _roleManager ??
            (_roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>());

        public IAuthenticationManager AuthenticationManager => _autenticationManaber ??
            (_autenticationManaber = HttpContext.GetOwinContext().Authentication);


        [AllowAnonymous]
        public ActionResult Registration() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(RegistrationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                var createdResult = await UserManager.CreateAsync(user, model.Password);
                if (createdResult.Succeeded)
                {
                    var roleAddResult = await UserManager.AddToRoleAsync(user.Id, "User");
                    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                    if (roleAddResult.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, true, false);
                        return View(model);
                    }
                }
                foreach (var error in createdResult.Errors)
                    ModelState.AddModelError(string.Empty, error);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (signInResult == SignInStatus.Success)
                    return View(model);
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}