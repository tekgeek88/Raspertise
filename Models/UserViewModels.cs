using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Raspertise.Models {

    public class CreateModel {

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }

    }
    

    public class LoginModel {

        [Required]

        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("email")]
        public string Email { get; set; }

        [Required]

        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string Password { get; set; }

        public class RoleEditModel {

            public IdentityRole Role { get; set; }
            public IEnumerable<AppUser> Members { get; set; }
            public IEnumerable<AppUser> NonMembers { get; set; }

        }

        public class RoleModificationModel {
            [Required] public string RoleName { get; set; }
            public string RoleId { get; set; }
            public string[] IdsToAdd { get; set; }
            public string[] IdsToDelete { get; set; }
        }
    }


    public class RegisterModel {

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        [Required]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("email")]
        public string Email { get; set; }
        
        public string UserName {
            get { return Email; }
        }

        [Required] public string Phone { get; set; }

        [Required]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string Password { get; set; }

        [Required]

        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string PasswordConfirm { get; set; }

        public string Role { get; set; }

    }


}