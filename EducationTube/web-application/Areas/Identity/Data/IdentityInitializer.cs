using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_application.Areas.Identity.Data.Models;

namespace web_application.Areas.Identity.Data
{
    public class IdentityInitializer
    {
        public static void InitializeDevelopment(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                RoleManager<EducationTubeRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<EducationTubeRole>>();
                EducationTubeRole adminRole = new EducationTubeRole("Administrator");

                if (!roleManager.RoleExistsAsync("Administrator").Result)
                {
                    _ = roleManager.CreateAsync(adminRole).Result;
                }


                UserManager<EducationTubeUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<EducationTubeUser>>();

                var user = userManager.FindByEmailAsync("default@default.com").Result;
                if (user == null)
                {
                    user = new EducationTubeUser() { UserName = "default@default.com", Email = "default@default.com" };
                    var createResult = userManager.CreateAsync(user, "Default1!").Result;
                }

                if (!userManager.IsInRoleAsync(user, adminRole.Name).Result)
                {
                    var roleAddResult = userManager.AddToRoleAsync(user, adminRole.Name).Result;
                }
            }
        }
    }
}
