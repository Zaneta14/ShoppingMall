using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingMall.Data;
using ShoppingMall.Models;

namespace ShoppingMall.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        private IPasswordValidator<AppUser> passwordValidator;
        private IUserValidator<AppUser> userValidator;
        private readonly ShoppingMallContext _context;

        public AdminController(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash, IPasswordValidator<AppUser> passwordVal, IUserValidator<AppUser>
userValid, ShoppingMallContext context)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
            passwordValidator = passwordVal;
            userValidator = userValid;
            _context = context;
        }

        public IActionResult Index()
        {
            IQueryable<AppUser> users = userManager.Users.OrderBy(u => u.Email);
            return View(users);
        }

        public IActionResult EmployeeProfile(int employeeId)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            AppUser user = userManager.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
            Employee employee = _context.Employee.Where(s => s.Id == employeeId).FirstOrDefault();
            if (employee != null)
            {
                ViewData["FullName"] = employee.FullName;
                ViewData["EmployeeId"] = employee.Id;
            }
            if (user != null)
                return View(user);
            else
                return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeProfile(int employeeId, string email, string password)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            AppUser user = userManager.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
            if (user != null)
            {
                IdentityResult validUser = null;
                IdentityResult validPass = null;

                user.Email = email;
                user.UserName = email;

                if (string.IsNullOrEmpty(email))
                    ModelState.AddModelError("", "Email cannot be empty");

                validUser = await userValidator.ValidateAsync(userManager, user);
                if (!validUser.Succeeded)
                    Errors(validUser);

                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    else
                        Errors(validPass);
                }

                if (validUser != null && validUser.Succeeded && (string.IsNullOrEmpty(password) || validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(EmployeeProfile), new { employeeId });
                    else
                        Errors(result);
                }
            }
            else
            {
                AppUser newuser = new AppUser();
                IdentityResult validUser = null;
                IdentityResult validPass = null;

                newuser.Email = email;
                newuser.UserName = email;
                newuser.EmployeeId = employeeId;
                newuser.Role = "Employee";

                if (string.IsNullOrEmpty(email))
                    ModelState.AddModelError("", "Email cannot be empty");

                validUser = await userValidator.ValidateAsync(userManager, newuser);
                if (!validUser.Succeeded)
                    Errors(validUser);

                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, newuser, password);
                    if (validPass.Succeeded)
                        newuser.PasswordHash = passwordHasher.HashPassword(newuser, password);
                    else
                        Errors(validPass);
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (validUser != null && validUser.Succeeded && validPass != null && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.CreateAsync(newuser, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newuser, "Employee");
                        return RedirectToAction(nameof(EmployeeProfile), new { employeeId });
                    }
                    else
                        Errors(result);
                }
                user = newuser;
            }
            Employee employee = _context.Employee.Where(s => s.Id == employeeId).FirstOrDefault();
            if (employee != null)
            {
                ViewData["FullName"] = employee.FullName;
                ViewData["TeacherId"] = employee.Id;
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}