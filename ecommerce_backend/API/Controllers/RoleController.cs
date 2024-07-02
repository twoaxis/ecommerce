using API.Dtos;
using API.Errors;
using Core.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class RoleController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesDto = new List<RoleDto>();
            foreach (var role in roles)
            {
                rolesDto.Add(new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name
                });
            }

            return Ok(rolesDto);
        }

        //[HttpPost]
        //public async Task<ActionResult<RoleDto>> CreateRole(string RoleName)
        //{
        //    var roleExist = await _roleManager.RoleExistsAsync(RoleName);
        //    if(!roleExist)
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole(RoleName));
        //        var role = await _roleManager.Roles.Where(O => O.Name == RoleName).FirstOrDefaultAsync();
        //        return Ok(new RoleDto() { Id = role.Id, Name = role.Name});
        //    }

        //    return BadRequest(new ApiResponse(400, "This role is already exist!"));
        //}

        [HttpPost("AddUserRole")]
        public async Task<ActionResult> AddUserRole(UserRoleDto userRole)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            if(user is null) 
                return BadRequest(new ApiResponse(404));
            var role = await _roleManager.FindByIdAsync(userRole.RoleId);
            if (role is null)
                return BadRequest(new ApiResponse(404));

            await _userManager.AddToRoleAsync(user, role.Name);
            return Ok(new {UserName = user.DisplayName, RoleName = role.Name});
        }
    }
}