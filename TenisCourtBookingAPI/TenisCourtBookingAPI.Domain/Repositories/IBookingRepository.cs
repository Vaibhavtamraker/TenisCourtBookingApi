using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Enums;

namespace TenisCourtBookingAPP.Domain.Repositories
{
    public interface IBookingRepository
    {
        List<Booking> ViewBookedCourtList(int UserId);

        bool UpdateBooking(Booking data);
        Booking GetBooking(int BookingId);
        void DeleteBooking(int BookingId);
        void CreateBooking(Booking booking);
    }
}
