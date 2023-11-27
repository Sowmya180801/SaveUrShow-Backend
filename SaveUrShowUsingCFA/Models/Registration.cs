using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.Models
{
    public class Registration
    {
        [Key]
        public int userid { get; set; }
        [Required(ErrorMessage = "username is reqd...!!")]
        public string username { get; set; }
        [Required(ErrorMessage = "Email is reqd...!!"),EmailAddress]
        [MinLength(8)]
        [MaxLength(30)]
        
        public string email { get; set; }
        [Required(ErrorMessage = "password is reqd...!!")]
        [MinLength(8)]
        [MaxLength(16)]
        public string password { get; set; }
        [Required(ErrorMessage = "confirm password is reqd...!!")]
        [Compare("password", ErrorMessage = "Password and Confirmation Password must match..")]
        public string confirmpassword { get; set; }
        public string usertype { get; set; }
    }
}
