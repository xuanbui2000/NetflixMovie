using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_PlantShop.Data;
using Project_PlantShop.Models;
using Project_PlantShop.Models.BindingModels;

namespace Project_PlantShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly PlantContext _context;
        private readonly IWebHostEnvironment _host;
        private readonly UserManager<PlantUser> _userManager;
        private readonly SignInManager<PlantUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(UserManager<PlantUser> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<PlantUser> signInManager, PlantContext context, IWebHostEnvironment host)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _host = host;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (!_context.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Staff"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Manager"));
                await _roleManager.CreateAsync(new IdentityRole<int>("User"));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel account)
        {
            var user = new PlantUser { UserName = account.Username };
            var result = await _userManager.CreateAsync(user, account.Password);
            TempData["UserName"] = account.Username;
            var username = (String)TempData["UserName"];
            if (result.Succeeded)
            {
                var _user = await _userManager.FindByNameAsync(username);
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction(nameof(FillProfile));
            }
            else
            {
                ViewData["Error"] = "PasswordTooShort,PasswordRequiresNonAlphanumeric,PasswordRequiresLower,PasswordRequiresUpper";
                return View();
            }

            return View(result);
        }

        [HttpGet]
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
        public async Task<IActionResult> Login(LoginModel loginModel, [FromServices] SignInManager<PlantUser> signInManager, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: false);
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



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var profile = await _context.Profile.Include(x => x.PlantUser).SingleOrDefaultAsync(x => x.UserId == user.Id);

            return View(profile);
        }

        private void GetNameMembers(int? selectedPersonId = null)
        {
            var people = _context.PlantUsers.AsNoTracking().ToList();
            ViewBag.User = new SelectList(people, "Email", "Id", selectedPersonId);
        }

        [HttpGet]

        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var profile = await _context.Profile.Include(x => x.PlantUser).SingleOrDefaultAsync(x => x.UserId == user.Id);

            return View(profile);
        }
        [Authorize(Roles = "Manager")]
        public class RoleUser
        {
            public int UserId { get; set; }
            public string RoleName { get; set; }
            public string EmailID { get; set; }
        }
        //[Authorize(Roles = "Manager")]
        public IActionResult EditRole()
        {
           ViewBag.Uer = (from a in _context.PlantUsers
                           join c in _context.UserRoles on a.Id equals c.UserId
                           join d in _context.Roles on c.RoleId equals d.Id
                           select new RoleUser
                           {
                               UserId = a.Id,
                               RoleName = d.Name,
                               EmailID = a.UserName
                           }).ToList();

            return View();
        }
        public async Task<IActionResult> EditRoleManager(int idUser, int roleId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser);
            var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == roleId);
            var roles = await _userManager.GetRolesAsync(new PlantUser { Id = idUser });
            await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
            await _userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]

        public async Task<IActionResult> EditProfile([Bind("UserId,FirstName,LastName,Gender,Dob,Address,Nationality,PhoneNumber")] Profile profile, IFormFile image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_host.WebRootPath + "/Images/User/", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    profile.Avatar = "/Images/User/" + image.FileName;

                }
                else
                {
                    profile.Avatar = "/Images/User/default-avatar.png";
                }

                _context.Profile.Update(profile);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(profile);
        }

        public async Task<IActionResult> FillProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FillProfile([Bind("FirstName,LastName,Gender,Address,Nationality,PhoneNumber")] Profile profile, IFormFile image)
        {
            Profile valide = profile;
            //profile.Avatar = image.FileName.ToString();
            //var imge=image.FileName.ToString();
            if (ModelState.IsValid)
            {
                var username = (String)TempData["UserName"];
                if (image != null)
                {
                    var imageName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(_host.WebRootPath + "/Images/User/", imageName);
                    await image.CopyToAsync(new FileStream(path, FileMode.Create));
                    profile.Avatar = "/Images/User/" + image.FileName;
                }
                else
                {
                    profile.Avatar = "/Images/User/" + "default-avatar.png";
                }
                var user = await _userManager.FindByNameAsync(username);
                // no login information here => User.Identity.Name = null
                var newProfile = await _context.Profile.Include(x => x.PlantUser).SingleOrDefaultAsync(x => x.UserId == user.Id);
                if (newProfile == null)
                {
                    profile.UserId = user.Id;
                    _context.Add(profile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }

            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Home");
        }
        //[HttpGet]
        //public IActionResult ManageRole(int id)
        //{
        //    var users = _context.Users.Include(u => u.Profile).ToList();
        //    ViewBag.Users = users;
        //    var roles = _roleManager.Roles.ToList();
        //    var currentRole = _context.UserRoles.FirstOrDefault(x => x.UserId == id);
        //    ViewBag.UserId = id;
        //    ViewBag.Roles = new SelectList(roles, "Id", "Name", currentRole?.RoleId);


        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ManageRole(IdentityUserRole<int> model)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
        //    var roles = await _userManager.GetRolesAsync(new PlantUser { Id = model.UserId });
        //    var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == model.RoleId);

        //    await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
        //    await _userManager.AddToRoleAsync(user, role.Name);
        //    return View("Update Role Result");

        //}

    }
}
