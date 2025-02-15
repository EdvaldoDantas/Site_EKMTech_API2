using Site_EKMTech_API2.Entities;

namespace Site_EKMTech_API2.Interfaces
{
    public interface IUserRepository
    {
        Task<RespModel<List<User>>> GetUsers();
        Task<RespModel<User>> GetUser(int id);
        Task<RespModel<User>> GetUser(string username);
        Task<RespModel<User>> AddUser(User user);
        Task<RespModel<User>> DeleteUser(int id);
    }
}
