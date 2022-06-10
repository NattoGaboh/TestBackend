using System;
using TestBackend.Domain.IRepository;
using TestBackend.Domain.Models;
using TestBackend.Persistence.Context;

namespace TestBackend.Persistence.Repository
{
	public class LoginRepository: ILoginRepository
	{
		public readonly ApplicationDbContext _context;
		public LoginRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User> ValidateUser(User user)
        {
			var usr = await _context.User.Where(x => x.NameUser.Equals(user.NameUser)
						&& x.Password.Equals(user.Password)).FirstOrDefaultAsync();
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return usr;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }
	}
}