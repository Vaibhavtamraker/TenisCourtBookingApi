using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;

namespace TenisCourtBookingAPP.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
       public  DbSet<User> Users { get; set; }
      
       public DbSet<Booking> Bookings { get; set; }
       
       public DbSet<TenisCourt> TenisCourts { get; set; }


        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
