using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie5.Models;

namespace Movie5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
          //  await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
           // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Models.BindingModels.LoginModel loginModel, [FromServices] SignInManager<MovieUser> signInManager, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("/Identity/Acount/Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            return View(loginModel);

        }
        public async Task<IActionResult> Logout([FromServices] SignInManager<MovieUser> signInManager)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("HomeMenu", "Home");
        }

        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register( Models.BindingModels.RegisterModel model, [FromServices] UserManager<MovieUser> registerManager, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Email = model.Email;
                user.UserName = model.Email;

                var result = await registerManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    var userId = registerManager.GetUserIdAsync(user);
                    if (registerManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                       
                        return LocalRedirect(returnUrl);
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(nameof(Index));

        }
        private MovieUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<MovieUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(MovieUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
