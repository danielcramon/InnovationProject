using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_application.Areas.Identity.Data.Models
{
    public class EducationTubeRole : IdentityRole
    {
        public EducationTubeRole() : base() { }
        public EducationTubeRole(string name) : base(name) { }
    }
}
