using Core.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace Repository.Identity
{
    public class IdentityContextSeeding
    {

        private async static Task AddRoles(RoleManager<IdentityRole> _roleManager)
        {
            if (_roleManager.Roles.Any())
                return;

            await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });
        }

        public async static Task SeedIdentityData(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            if(_userManager.Users.Any())
                return;
            
            var user = new AppUser()
            {
                DisplayName = "Ahmed",
                Email = "ahmedeldamity25@gmail.com",
                UserName = "ahmedeldamity25",
                PhoneNumber = "01110796304",
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(user, "123QWEzxc#");
            await AddRoles(_roleManager);
            await _userManager.AddToRoleAsync(user, "Admin");
        } 
    }
}