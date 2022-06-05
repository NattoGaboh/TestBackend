using Microsoft.AspNetCore.Mvc;
using TestBackend.Domain.IServices;
using TestBackend.Domain.Models;
using TestBackend.DTO;
using TestBackend.Utils;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                var validateExistence = await _userService.ValidateExistence(user);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario "+user.NameUser+" ya existe." });
                }
                user.Password = Utilities.EncrpytPassword(user.Password);
                await _userService.SaveUser(user);
                return Ok(new { message = "Usuario Registrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CambiarPassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                int IdUser = 3;
                string passwordEncrypt = Utilities.EncrpytPassword(changePasswordDTO.PasswordBefore);
                var user = await _userService.ValidatePassword(IdUser, passwordEncrypt);
                if (user == null)
                {
                    return BadRequest(new { message = "La contraseña es incorrecta." });
                }
                else
                {
                    user.Password = Utilities.EncrpytPassword(changePasswordDTO.PasswordNew);
                    await _userService.UpdatePassword(user);
                    return Ok(new { message = "La contraseña fue cambiada con éxito." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
