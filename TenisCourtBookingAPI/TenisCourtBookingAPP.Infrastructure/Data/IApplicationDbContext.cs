using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;

namespace TenisCourtBookingAPP.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<TenisCourt> TenisCourts { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
