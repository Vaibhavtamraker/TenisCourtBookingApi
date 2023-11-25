using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Repositories;
using TenisCourtBookingAPP.Infrastructure.Data;

namespace TenisCourtBookingAPP.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public bool AuthenticateUser(string email, string password, out User? user)
        { 
            bool result = false;
            user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if(user == null)
            {
                return result;
            }
            else
            {
                return true;
            }
            
        }

      

        public bool IsEmailAvailable(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);    
            if(user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegisterUser(User user)
        {
           _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
