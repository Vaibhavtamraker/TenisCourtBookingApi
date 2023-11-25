using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Enums;
using TenisCourtBookingAPP.Domain.Repositories;

namespace TenisCourtBookingAPP.Application.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _BookingRepository;
        public BookingService(IBookingRepository bookingrepo)
        {
            _BookingRepository = bookingrepo;
        }
        public List<Booking> ViewAvailableCourt(int UserId)
        {
            return _BookingRepository.ViewBookedCourtList(UserId);
        }
        public bool UpdateBooking(Booking obj)
        {
          
            if (obj == null)
            {
                return false;
            }
            else
            {
              
                _BookingRepository.UpdateBooking(obj);
                return true;
            }
        }

        public bool DeleteBooking(int BookingId)
        {
            if (_BookingRepository.GetBooking(BookingId) == null)
            {
                return false;
            }
            else
            {
                _BookingRepository.DeleteBooking(BookingId);
                return true;
            }
        }
        public bool Createbooking(Booking data)
        {
            if (data != null)
            {
                _BookingRepository.CreateBooking(data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
