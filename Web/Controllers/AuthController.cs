using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<K205User> _userManager;
        private readonly SignInManager<K205User> _signInManager;

        public AuthController(UserManager<K205User> userManager, SignInManager<K205User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            K205User user = new()
            {
                UserName = registerVM.Name,
                Name = registerVM.Name,
                Surname = registerVM.Name,
                Email = registerVM.Email,
                About = registerVM.Name,
                PhotoURL = registerVM.Name
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);


            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View("Error");
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
