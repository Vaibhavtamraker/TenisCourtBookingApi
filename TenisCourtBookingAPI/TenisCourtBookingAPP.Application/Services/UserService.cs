using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Repositories;
using TenisCourtBookingAPP.Infrastructure.Repositories;

using TenisCourtBookingAPP.Infrastructure.Services;

namespace TenisCourtBookingAPP.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public readonly  IConfiguration configuration;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        
        }
        public void RegisterUser(User user)
        {
            if(user == null)
            {
               throw new ArgumentNullException("user");
            }
            else
            {
               if (_userRepository.IsEmailAvailable(user.Email))
                {
                    _userRepository.RegisterUser(user);
                }

                else
                {
                    throw new Exception($"This {user.Email} is Already Exists!");
                }
            }
          
        }

        public string AuthenticateUser(string email,string password )
        {
            if (_userRepository.AuthenticateUser(email, password,out User? user))
            {

                if (user != null)
                {
                    var jwt = new JwtService("ACDt1vR3lXToPQ1g3MyNJHjkhdkjshkjh","10");
                    var token = jwt.GenerateToken(user);
                    return token;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return $"Invalid Credential for this {email}";
            }
        }

    }
}
