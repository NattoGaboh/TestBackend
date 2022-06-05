using TestBackend.Domain.Models;

namespace TestBackend.Domain.IServices
{
    public interface ILoginService
	{
		Task<User> ValidateUser(User user);
	}
}

