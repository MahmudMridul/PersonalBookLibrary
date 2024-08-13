using LibraryAPI.Db;
using LibraryAPI.Models;
using LibraryAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _db;

        public UserRepository(LibraryContext db) 
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> RegisterUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _db.Users.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
