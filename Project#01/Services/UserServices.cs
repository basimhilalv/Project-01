using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_01.Data;
using Project_01.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_01.Services
{
    public class UserServices : IUserServices
    {
        private readonly ProjectDbContext _context;
        public UserServices(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) return null;
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users is null) return null;
            return users;
        }

        public async Task<string> LoginUser(LoginDto user)
        {
            var userlog = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (userlog is null) return null;
            if (!BCrypt.Net.BCrypt.Verify(user.Password, userlog.Password)) return null;
            var token = CreateToken(userlog);
            return token;
        }

        public async Task<User> RegisterUser(UserDto user)
        {
            if(await _context.Users.AnyAsync(u=> u.Email == user.Email))
            {
                return null;
            }
            var userreg = new User();
            userreg.Username = user.Username;
            userreg.Email = user.Email;
            userreg.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(userreg);
            await _context.SaveChangesAsync();
            return userreg;
        }

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("supersecretkeyofbasimhilalisfamousforeverythingthattoughtinthiseraoftechnologyandresearchokthenbye");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
