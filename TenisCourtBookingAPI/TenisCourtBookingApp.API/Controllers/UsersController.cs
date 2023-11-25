using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenisCourtBookingAPP.Application.Services;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Repositories;
using TenisCourtBookingAPP.Infrastructure.Data;
using TenisCourtBookingAPP.Infrastructure.Repositories;

namespace TenisCourtBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        public UsersController(IApplicationDbContext context)
        {
            _context = context; 
        }
        [HttpPost("CreateAccount")]
        public IActionResult RegisterUser(User user)
        {
            try
            {
                var userService = new UserService(new UserRepository(_context));
                userService.RegisterUser(user);
                return Ok($"User registered Successfully! with {user.Email}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Login")]
        public IActionResult Login(string email,string password)
        {
            try
            {

                var userService = new UserService(new UserRepository(_context));
                return Ok(userService.AuthenticateUser(email, password));
               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
