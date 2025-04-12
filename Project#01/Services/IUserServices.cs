using Project_01.Models;

namespace Project_01.Services
{
    public interface IUserServices
    {
        public Task<User> RegisterUser(UserDto user);
        public Task<string> LoginUser(LoginDto user);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserById(int id);
    }
}
