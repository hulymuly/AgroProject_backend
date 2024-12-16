using System.Security.Claims;
using System.Text;
using AgroProject.Data;
using AgroProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace AgroProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<Sotrudniki> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IPasswordHasher<Sotrudniki> passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        #region Регистрация

        // Регистрация пользователя
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // Проверяем, существует ли сотрудник с таким логином
            if (await _context.Sotrudnikis.AnyAsync(u => u.Login == model.Login))
            {
                return BadRequest("User with this login already exists.");
            }

            var user = new Sotrudniki
            {
                Name = model.Name,
                Surname = model.Surname,
                Login = model.Login,
                Patronicname = model.Patronicname,
                Role = model.RoleId // Присваиваем роль пользователю
            };

            // Хешируем пароль
            user.Password = _passwordHasher.HashPassword(user, model.Password);

            _context.Sotrudnikis.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        #endregion

        #region Логин и получение JWT

        // Логин и получение JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _context.Sotrudnikis.FirstOrDefaultAsync(u => u.Login == model.Login);

            // Проверяем, что пользователь найден и пароль совпадает
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid credentials.");
            }

            // Генерация JWT токена
            var token = GenerateJwtToken(user);

            // Создаем сессию для пользователя
            var session = new Sessium
            {
                IdPolzovat = user.Id,
                DateTimeSozd = DateTime.Now
            };
            _context.Sessia.Add(session);
            await _context.SaveChangesAsync();

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Sotrudniki user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())  // Роль пользователя
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }

    // Модели для регистрации и логина
public class RegisterModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Patronicname { get; set; }
    public int RoleId { get; set; }  // ID роли пользователя
}

public class LoginModel
{
    public string Login { get; set; }
    public string Password { get; set; }
}
}