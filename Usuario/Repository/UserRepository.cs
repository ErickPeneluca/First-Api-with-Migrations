using Microsoft.EntityFrameworkCore;
using Usuario.Data;
using Usuario.Models;
using Usuario.Repository.Interfaces;

namespace Usuario.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<User> FindUser(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<User>> FindUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public void DelUser(User user)
        {
            _context.Remove(user);
        }

        public void EditUser(User user)
        {
            _context.Update(user);
        }




        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
