using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Movie6.Models;
using Movie6.Models.BindingModels;
using System.Text;

namespace Movie6.Controllers
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
            returnUrl ??= Url.Content("`~/");
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

        public IActionResult Logout(string returnUrl)
        {
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage(Url.Content("~/"));
            }
            return View();
        }
        //public IActionResult Register(string returnUrl)
        //{
        //    ReturnUrl = returnUrl;
        //    //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    return View();
        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPost(Models.BindingModels.RegisterModel model, [FromServices] UserManager<MovieUser> registerManager, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                var result = await registerManager.CreateAsync(user, model.Password);
                var code = await registerManager.GenerateEmailConfirmationTokenAsync(user);
                if (result.Succeeded)
                {

                    var userId = registerManager.GetUserIdAsync(user);
                    //var code = registerManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (registerManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
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


        //public string ReturnUrl { get; set; }
        //public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
