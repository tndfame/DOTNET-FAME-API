using FAME_PROEJCT_API.Models.Entity;
using FAME_PROEJCT_API.Models.Request;
using FAME_PROEJCT_API.Service;
using Microsoft.AspNetCore.Mvc;

namespace FAME_PROEJCT_API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserService _adminUserService;

        public AdminUserController(IAdminUserService userService)
        {
            _adminUserService = userService;
        }

        [HttpPost("register")]
            public async Task<IActionResult> RegisterUser([FromBody] AdminUser user)
        {
            try
            {
                var registrationResult = await _adminUserService.RegisterUserAsync(user);
                if (registrationResult)
                {
                    return Ok(new { Success = true, Message = "Registration successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Registration failed. Please try again." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, new { Success = false, Message = "Failed" });
            }
        }



        [HttpPost("checkedUserByLogin")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _adminUserService.CheckedUserByLogin(request.Email, request.Password);
                if (user != null)
                {
                    return Ok(new { success = true, user });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Invalid email or password" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Internal Server Error" });
            }
        }
    }
}
