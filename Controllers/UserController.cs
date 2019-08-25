using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.SqlServer.Server;
using Raspertise.Models;
using Remotion.Linq.Clauses.ResultOperators;

namespace Raspertise.Controllers {

    public class UserController : Controller {
        
        private UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userMgr) {
            userManager = userMgr;
        }

        [Authorize(Roles = "Admin, Sponsor, Advertiser")]
        public IActionResult Details() => View(GetData(nameof(Details)));

        
        [Authorize(Roles = "Admin, Sponsor, Advertiser")]
        public IActionResult OtherAction() => View("Details", GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) {

            string[] roles = {"Admin", "Sponsor", "Advertiser"};
            List<string> names = new List<string>();
            string user_roles = "";

            foreach (string r in roles) {
                if (HttpContext.User.IsInRole(r)) {
                    names.Add(r);
                }
            }

            string final_result = names.Count == 0 ? "No Roles" : string.Join(", ", names);

            Dictionary<string, object> result = new Dictionary<string, object> {
                ["Id"] = CurrentUser.Result.Id,
//                ["First Name"] = CurrentUser.Result.FirstName,
//                ["Last Name"] = CurrentUser.Result.LastName,
                ["User Name"] = HttpContext.User.Identity.Name,
                ["Email"] = CurrentUser.Result.Email,
                ["Email isConfirmed"] = CurrentUser.Result.EmailConfirmed,
                ["Phone Number"] = CurrentUser.Result.PhoneNumber,
                ["Phone Number isConfirmed"] = CurrentUser.Result.PhoneNumberConfirmed,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["Role"] = final_result
            };
            return result;
        }
        

        [Authorize]
        public async Task<IActionResult> Edit() {
            return View(await CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(
            [Required] string firstName,
            [Required] string lastName) {
            if (ModelState.IsValid) {
                AppUser user = await CurrentUser;
//                user.FirstName = firstName;
//                user.LastName = lastName;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Details");
            }

            return View(await CurrentUser);
        }

        private Task<AppUser> CurrentUser =>
            userManager.FindByNameAsync(HttpContext.User.Identity.Name);

    }

}