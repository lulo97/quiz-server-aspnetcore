using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Security.Claims;
using static Backend.Utils.Const;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("CurrentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null) return Ok(new { User = (AnyType?)null });
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) return Problem(RECORD_NOT_FOUND);
                return Ok(new { User = user }); //Ok() must take json object as parameter
            }
            catch
            {
                return Problem(READ_FAIL);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                if (model.UserName == null) return Problem("Tên đăng nhập trống!");
                if (model.Password == null) return Problem("Mật khẩu trống!");

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.IsLockedOut) return Problem("Tài khoản bị khóa!");
                if (result.IsNotAllowed) return Problem("Không được phép đăng nhập!");
                if (result.Succeeded) return NoContent();
                return Problem("Lỗi đăng nhập");
            }
            catch
            {
                return Problem("Lỗi đăng nhập");
            }
        }
    }
}


