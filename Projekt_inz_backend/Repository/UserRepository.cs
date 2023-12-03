using Microsoft.IdentityModel.Tokens;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Dto;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Projekt_inz_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DndDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(DndDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string CreateToken(UserDto user)
        {
            User userEntity = _context.Users.Where(b => b.username == user.username).FirstOrDefault();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userEntity.username),
                new Claim(ClaimTypes.Role, userEntity.role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(int id)
        {
            User userEntity = _context.Users.Where(b => b.userID == id).FirstOrDefault();
            _context.Remove(userEntity);
            return Save();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(b => b.userID == id).FirstOrDefault();
        }

        public User GetUserByName(string username)
        {
            return _context.Users.Where(b => b.username == username).FirstOrDefault();
        }
        

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(b => b.userID).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool VerifyEmail(string email)
        {
            if (_context.Users.Any(b => b.email == email))
                return true;
            else
                return false;
        }

        public bool VerifyPassword(UserDto user)
        {
            using (var hmac = new HMACSHA512(_context.Users.Where(b => b.username == user.username).FirstOrDefault().passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.password));
                return computedHash.SequenceEqual(_context.Users.Where(b => b.username == user.username).FirstOrDefault().passwordHash);
            }
        }

        public bool VerifyUsername(string username)
        {
            if (_context.Users.Any(b => b.username == username))
                return true;
            else
                return false;
        }
    }
}
