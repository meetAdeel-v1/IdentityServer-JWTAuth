using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer_JWTAuth.Models
{
    public class UserSignup
    {
        //public int Id { get; set; }
        [Required(ErrorMessage ="This Field is Required.")]
        [Display(Name ="Test")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
