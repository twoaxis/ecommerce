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
            var roles = await _roleManager.Roles.Select(role => new RoleDto{ Id = role.Id, Name = role.Name }).ToListAsync();
            return Ok(roles);
        }

        [HttpPost("AddUserRole")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddUserRole(UserRoleDto userRole)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            if(user is null)
                return NotFound(new ApiResponse(404, "User not found."));
            var role = await _roleManager.FindByIdAsync(userRole.RoleId);
            if (role is null)
                return NotFound(new ApiResponse(404, "Role not found"));

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400, "Failed to add role to user"));

            return Ok(new {UserName = user.DisplayName, RoleName = role.Name});
        }
    }
}