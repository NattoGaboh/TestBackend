using TestBackend.Domain.IRepository;
using TestBackend.Domain.Models;
using TestBackend.Persistence.Context;

namespace TestBackend.Persistence.Repository
{
	public class UserRepository: IUserRepository
	{
		private readonly ApplicationDbContext _context;
		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task SaveUser(User user)
        {
			_context.Add(user);
			await _context.SaveChangesAsync();
        }

		public async Task<bool> ValidateExistence(User user)
        {
			var validateExistence = await _context.User.AnyAsync(x => x.NameUser == user.NameUser);
			return validateExistence;
        }
		public async Task<User> ValidatePassword(int idUser,string passwordBefore)
        {
			var user = await _context.User.Where(x => x.Id == idUser && x.Password == passwordBefore).FirstOrDefaultAsync();
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return user;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

		public async Task UpdatePassword(User user)
        {
			_context.Update(user);
			await _context.SaveChangesAsync();
        }
	}
}

