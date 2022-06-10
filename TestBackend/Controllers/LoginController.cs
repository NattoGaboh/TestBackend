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
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService,IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
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
                string tokenString = JwtConfigurator.GetToken(usr, _config);
                //return Ok(new { usuario = usr.NameUser });
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
