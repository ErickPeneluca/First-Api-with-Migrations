using Usuario.Models;

namespace Usuario.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindUsers();

        Task<User> FindUser(int id);

        void AddUser(User user);

        void EditUser(User user);

        void DelUser(User user);

        Task<bool> SaveChangesAsync();

    }
}
