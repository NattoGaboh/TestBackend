using System;
using TestBackend.Domain.IRepository;
using TestBackend.Domain.IServices;
using TestBackend.Domain.Models;

namespace TestBackend.Services
{
	public class LoginService: ILoginService
	{
		public readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}

		public async Task<User> ValidateUser(User user)
        {
			return await _loginRepository.ValidateUser(user);
        }
	}
}

