

using Microsoft.AspNetCore.Mvc;
using Gestpsfe.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication2.Migrations;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Services.UserService;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{ [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PfeContext _context;
        private static User myuser;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IConfiguration configuration, IUserService userService, PfeContext context , IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _userService = userService;
            _context = context;
            _authenticationService = authenticationService;
        }


        /*
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            CreatePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);

            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PermissionId = 1;
           
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        */
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(authuser u)
        {  

              if (!_context.Users.Any())
    {

                _context.Users.AddRange(
        new User
        { Nom = "admin",
            Email = "admin@gmail.com",
            password = "admin@gmail.com",
            Matricule = "ABC123",
            RoleId = 1,
            PermissionId = 1,
            Plansection = "Section A",
            Segment = "Segment 1",
            ListePlanificationId = 1,
            ShiftId = 1,
            Salaire = 0000.0,
            TokenCreated = DateTime.Now,
            TokenExpires = DateTime.Now.AddDays(7)
        }
      
    );

                _context.SaveChanges();
    }







            myuser = await _context.Users.Include(e => e.Role)
                  .FirstOrDefaultAsync(e => e.password == u.Mdp && e.Email==u.Email);
            if (myuser == null)
            {
                return BadRequest("Wrong Email Or Password.");
            }
            CreatePasswordHash(myuser.password, out byte[] passwordHash, out byte[] passwordSalt);


            myuser.PasswordHash = passwordHash;
            myuser.PasswordSalt = passwordSalt;
            if (!VerifyPasswordHash(u.Mdp, myuser.PasswordHash, myuser.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(myuser);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            var response = new
            { 
                Token = token,
                UserId = myuser.Id,
                Role = myuser.Role.RoleName,
                PermissionId = myuser.PermissionId,
                routes = myuser.Role.Description
            };

            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
   
            return Ok("Logged out successfully");
        }
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!myuser.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if(myuser.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(myuser);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            myuser.RefreshToken = newRefreshToken.Token;
            myuser.TokenCreated = newRefreshToken.Created;
            myuser.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nom),
                new Claim(ClaimTypes.Role, user.RoleId+"")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}