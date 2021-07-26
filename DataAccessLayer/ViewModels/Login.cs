using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the UserName/Email")]
        [Display(Name ="Email/Username")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
