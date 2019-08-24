using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raspertise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Raspertise.Controllers {

    [Authorize]
    public class AccountController : Controller {

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private ILogger<DebugLoggerProvider> loggerDebug;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr) {
            userManager = userMgr;
            signInManager = signInMgr;
        }


        [AllowAnonymous]
        public IActionResult Login(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        
        
        [AllowAnonymous]
        public IActionResult RegisterSponsor(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            ViewBag.roleIdentity = "Sponsor";
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterSponsor(RegisterModel model, string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            
            if (ModelState.IsValid) {
                var user = new AppUser {UserName = model.Email, Email = model.Email};
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, "Sponsor");
                    await signInManager.SignInAsync(user, isPersistent: false);
                }
                
                return Redirect(returnUrl ?? "/");
            }
            
            ModelState.AddModelError("Failed",
                "Unable to register a sponsor!");

            return View(returnUrl);
        }

        [AllowAnonymous]
        public IActionResult RegisterAdvertiser(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            ViewBag.roleIdentity = "Advertiser";
            return View();
        }
        
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdvertiser(RegisterModel model, string returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            
            if (ModelState.IsValid) {
                var user = new AppUser {UserName = model.Email, Email = model.Email};
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, "Advertiser");
                    await signInManager.SignInAsync(user, isPersistent: false);
                }
                
                return Redirect(returnUrl ?? "/");
            }
            
            ModelState.AddModelError("Failed",
                "Unable to register a advertiser!");

            return View(returnUrl);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details,
            string returnUrl) {
            if (ModelState.IsValid) {
                AppUser user = await userManager.FindByEmailAsync(details.Email);

                if (user != null) {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(
                            user, details.Password, false, false);

                    if (result.Succeeded) {
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginModel.Email),
                    "Invalid user or password");
            }

            return View(details);
        }


        [Authorize]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied() {
            return View();
        }

    }


}