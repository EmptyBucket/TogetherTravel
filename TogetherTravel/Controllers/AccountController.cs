﻿using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataBase.Models.User;
using Microsoft.AspNet.Identity.Owin;
using TogetherTravel.ViewModels;

namespace TogetherTravel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        private ApplicationUserManager _userManager;

        private ApplicationSignInManager _signInManager;

        public AccountController(IMapper mapper, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _mapper = mapper;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        [AllowAnonymous]
        public ActionResult Registration() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registration(RegistrationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                var identityAsync = await UserManager.CreateAsync(user, model.Password);
                if (identityAsync.Succeeded)
                {
                    await SignInManager.SignInAsync(user, true, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in identityAsync.Errors)
                    ModelState.AddModelError(string.Empty, error);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (signInResult == SignInStatus.Success)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}