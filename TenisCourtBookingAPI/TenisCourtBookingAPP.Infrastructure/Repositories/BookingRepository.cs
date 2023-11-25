using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Enums;
using TenisCourtBookingAPP.Domain.Repositories;
using TenisCourtBookingAPP.Infrastructure.Data;

namespace TenisCourtBookingAPP.Infrastructure.Repositories
{
    public class BookingRepository: IBookingRepository
    {
        private readonly IApplicationDbContext _IApplicationDbContext;
        public BookingRepository(IApplicationDbContext dbContext)
        {
            _IApplicationDbContext = dbContext;
        }

        public void CreateBooking(Booking booking)
        {
            
            _IApplicationDbContext.Bookings.Add(booking);
            _IApplicationDbContext.SaveChanges();
        }

        public void DeleteBooking(int BookingId)
        {
            _IApplicationDbContext.Bookings.Remove(GetBooking(BookingId));
            _IApplicationDbContext.SaveChanges();
        }

        public Booking GetBooking(int BookingId)
        {
            Booking value = _IApplicationDbContext.Bookings.FirstOrDefault(x => x.BookingId == BookingId);
            if (value != null)
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateBooking(Booking data)
        {
            if (data != null)
            {
                _IApplicationDbContext.Bookings.Update(data);
                _IApplicationDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Booking> ViewBookedCourtList(int UserId)
        {
            var result = _IApplicationDbContext.Bookings.ToList<Booking>().Where(x => x.UserId == UserId);
            return result.ToList();
        }
    }
}
