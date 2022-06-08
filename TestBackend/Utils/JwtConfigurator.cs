using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestBackend.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace TestBackend.Utils
{
	public class JwtConfigurator
	{
		public static string GetToken(User userInfo, IConfiguration config)
        {
			string secretKey = config["Jwt:SecretKey"];
			string Issuer = config["Jwt:Isuser"];
			string Audience = config["Jwt:Audience"];

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, userInfo.NameUser),
				new Claim("idUsuario",userInfo.Id.ToString())
			};
			var token = new JwtSecurityToken(
				issuer: Issuer,
				audience: Audience,
				claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: credentials
				) ;
			return new JwtSecurityTokenHandler().WriteToken(token);
        }
	}
}

