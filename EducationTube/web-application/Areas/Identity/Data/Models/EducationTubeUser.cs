using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace web_application.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EducationTubeUser class
    public class EducationTubeUser : IdentityUser
    {
        [Required]
        public int Tokens { get; set; }
    }
}
