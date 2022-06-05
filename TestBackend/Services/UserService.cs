using TestBackend.Domain.IRepository;
using TestBackend.Domain.IServices;
using TestBackend.Domain.Models;

namespace TestBackend.Services
{
	public class UserService: IUserService
	{
		public readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task SaveUser(User user)
        {
			await _userRepository.SaveUser(user);
        }
		public async Task<bool> ValidateExistence(User user)
        {
			return await _userRepository.ValidateExistence(user);
        }
		public async Task<User> ValidatePassword(int idUser, string passwordBefore)
        {
			return await _userRepository.ValidatePassword(idUser, passwordBefore);
        }
		public async Task UpdatePassword(User user)
        {
			await _userRepository.UpdatePassword(user);
        }
	}
}

