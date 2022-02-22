

using AutoMapper;
using Hospital_Managment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using SampleApi.Mapper;
using SampleApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SampleApi.Repository
{
    public class UsersRepository:IUsersRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsersRepository(ApplicationDbContext applicationDb, IMapper mapper, IConfiguration config)
        {
            _db=applicationDb;
            _mapper=mapper;
            _config=config;
         
        }

        public bool GetRegister(UsersDTO dto)

        {
            Users user = new Users();

            user.Name=dto.Name;
            user.Email=dto.Email;
            user.Password=dto.Password; 
            user.Id=dto.Id;
              _db.Users.Add(user);

            return Save();

        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ? true : false;
        }

       public async Task<UsersDTO> Login(LoginDTO dto)
        {
            var obj = await _db.Users.Where(x => x.Email == dto.Email && x.Password ==dto.Password).SingleOrDefaultAsync();
            string token = CreateToken(obj!);
            var ValidUser = _mapper.Map<UsersDTO>(obj);
            ValidUser.Token=token;
            return ValidUser;
        }

        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name!),
                //new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public ICollection<Users> GetUsers()
        {
            var obj= _db.Users.ToList();
            return obj;
        }
    }
}


public interface IUsersRepository
{

    public   bool GetRegister(UsersDTO user);

    public    Task <UsersDTO>Login(LoginDTO dto);
    public ICollection<Users> GetUsers();

}