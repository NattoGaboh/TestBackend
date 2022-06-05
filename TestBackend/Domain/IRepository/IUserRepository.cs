using TestBackend.Domain.Models;

namespace TestBackend.Domain.IRepository
{
	public interface IUserRepository
	{
		Task SaveUser(User user);
		Task<bool> ValidateExistence(User user);
		Task<User> ValidatePassword(int idUser, string passwordBefore);
		Task UpdatePassword(User user);
	}
}

