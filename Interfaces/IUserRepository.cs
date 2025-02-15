using Site_EKMTech_API2.Entities;

namespace Site_EKMTech_API2.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUser(string username);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(int id);
    }
}
