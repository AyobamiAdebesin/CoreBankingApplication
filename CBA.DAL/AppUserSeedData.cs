using CBA.Core.Models;
using CBA.Core.Enums;
using CBA.DAL.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CBA.DAL
{
    public class AppUserSeedData
    {

        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AppUserSeedData(AppDbContext _context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context = _context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedAdminUserAndRoles()
        {
            string[] roles = new string[]
            {
                "Super Admin",
                 "Admin",
                 "Tester",
                 "Manager",
                 "Auditor",
                 "Developer",
            };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<ApplicationRole>(context);

                if (context.Roles.Any(r => r.Name == role))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role, State = Status.Enabled, NormalizedName = role.ToUpper() });
                }
            }
            var user = new ApplicationUser
            {
             //   UserName = "bolexcoded43@gmail.com",
                FirstName = "Boluwatife",
                LastName = "Oyetoro",
                Email = "bolexcoded43@gmail.com",
                Gender = Core.Enums.Gender.Any,
                Status = Status.Enabled,
            };

            if (!context.Users.Any(u => u.Email == user.Email))
            {
                //var password = new PasswordHasher<ApplicationUser>();
                //var hashed = password.HashPassword(user, "password");
                //user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "SUPER ADMIN");
            }

            await context.SaveChangesAsync();

        }
    }
}
