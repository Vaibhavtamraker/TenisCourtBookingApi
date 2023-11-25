using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;

namespace TenisCourtBookingAPP.Domain.Repositories
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        bool AuthenticateUser(string email, string password, out User? user);
        bool IsEmailAvailable(string email);
       
    }
}
