using Microsoft.EntityFrameworkCore;
using Site_EKMTech_API2.Entities;
using Site_EKMTech_API2.Interfaces;

namespace Site_EKMTech_API2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<RespModel<User>> AddUser(User user)
        {
            var resp = new RespModel<User>();
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                resp.Data = user;
                resp.Message = "User added successfully";
                resp.Success = true;
            }
            catch(Exception e)
            {
                resp.Message = "Ocorreu algum erro interno " + e.Message;
            }
            return resp;    
        }

        public async Task<RespModel<User>> DeleteUser(int id)
        {
            var resp = new RespModel<User>();
            try
            {
                var user = await _context.Users.FirstAsync(u => u.Id == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                resp.Message = "Usuário deletado com sucesso";
                resp.Success = true;
                return resp;
            }
            catch(Exception ex)
            {
                resp.Message = "Ocorreu algum erro interno " + ex.Message;
                return resp;
            }
        }

        public async Task<RespModel<User>> GetUser(int id)
        {
            var resp = new RespModel<User>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if(user == null)
                {
                    resp.Message = "usuário não encontrado";
                    return resp;
                }
                resp.Data = user;
                resp.Message = "usuário encontrado com sucesso";
                resp.Success = true;
            }
            catch(Exception e)
            {
                resp.Message = "Ocorreu algum erro interno " + e.Message;
            }
            return resp;
        }

        public async Task<RespModel<User>> GetUser(string username)
        {
            var resp = new RespModel<User>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if(user == null)
                {
                    resp.Message = "usuário não encontrado";
                    return resp;
                }
                resp.Data = user;
                resp.Message = "usuário encontrado com sucesso";
                resp.Success = true;
            }
            catch(Exception e)
            {
                resp.Message = "Ocorreu algum erro interno " + e.Message;
            }
            return resp;
        }

        public async Task<RespModel<List<User>>> GetUsers()
        {
            var resp = new RespModel<List<User>>();
            try
            {
                var users = await _context.Users.ToListAsync();
                resp.Data = users;
                resp.Message = "Usuários encontrados com sucesso";
                resp.Success = true;
            }
            catch(Exception e)
            {
                resp.Message = "Ocorreu algum erro interno " + e.Message;
            }
            return resp;
        } 
    }
}
