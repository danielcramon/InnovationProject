using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_application.Models
{
    public class AuthenticationViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public AuthenticationViewModel() { }
    }
}
