using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_application.Areas.Identity.Data;
using web_application.Areas.Identity.Data.Models;

namespace web_application.Data
{
    public class EducationTubeContext : IdentityDbContext<EducationTubeUser, EducationTubeRole, string>
    {
        public EducationTubeContext(DbContextOptions<EducationTubeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
