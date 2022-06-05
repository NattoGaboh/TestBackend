using TestBackend.Domain.Models;

namespace TestBackend.Domain.IRepository
{
    public interface ILoginRepository
	{
		Task<User> ValidateUser(User user);
	}
}

