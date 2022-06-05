using Microsoft.AspNetCore.Mvc;
using TestBackend.Domain.IServices;
using TestBackend.Domain.Models;
using TestBackend.Utils;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            try
            {
                user.Password = Utilities.EncrpytPassword(user.Password);
                var usr = await _loginService.ValidateUser(user);
                if (usr == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña inválida" });
                }
                return Ok(new { message = "xXx" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
