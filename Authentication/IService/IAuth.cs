using Helpers;
using Microsoft.AspNetCore.Mvc;
using Simple_Store.DTO;
using System.Threading.Tasks;

namespace Simple_Store.Auth.IService
{
    public interface IAuth
    {
        Task<Response> Login(LoginDTO model);
        Task<Response> Register(RegisterDTO model);
        Task<Response> Logout();
    }
}
