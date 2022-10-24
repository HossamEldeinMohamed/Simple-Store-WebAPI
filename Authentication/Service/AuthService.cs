
using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Simple_Store.Auth.IService;
using Simple_Store.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Simple_Store.Simple_Store.Auth.IService.Service
{
    public class AuthService : IAuth
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        public async Task<Response> Login(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);  
                return new Response { Code= 200 , Data = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
                };
            }
            return new Response { Code = 401, Message = "Unauthorized" };
        }

        public async Task<Response> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new Response { Code=200};
            }
            catch (Exception e)
            {
                return new Response { Code = 404 , Message = e.Message};
            }

        }

        public async Task<Response> Register(RegisterDTO model)
        {
            var ckeckEmail = await _userManager.FindByEmailAsync(model.Email);
            if (ckeckEmail != null)
                return new Response { Code = 400 , Message ="Email Found"};
            var user = new IdentityUser { UserName = model.Email, Email = model.Email  };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return new Response { Code = 200 , Data = user};
            }               
            else
                return new Response { Code = 404 , Message="fail"};
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}  
