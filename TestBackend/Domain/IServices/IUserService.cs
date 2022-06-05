using TestBackend.Domain.Models;

namespace TestBackend.Domain.IServices
{
    public interface IUserService
	{
		Task SaveUser(User user);
		Task<bool> ValidateExistence(User user);
		Task<User> ValidatePassword(int idUser, string passwordBefore);
		Task UpdatePassword(User user);
	}
}

