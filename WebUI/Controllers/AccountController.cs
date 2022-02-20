using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModel;

namespace WebUI.Controllers
{   
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe , false);
                
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Administration");
                }

                ModelState.AddModelError(String.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser { Email = model.Email, UserName = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);


                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return View("Index", "Home");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
    }
}
