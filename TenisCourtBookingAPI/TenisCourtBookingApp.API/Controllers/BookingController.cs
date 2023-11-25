using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenisCourtBookingAPP.Application.Services;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Enums;
using TenisCourtBookingAPP.Domain.Repositories;
using TenisCourtBookingAPP.Infrastructure.Data;
using TenisCourtBookingAPP.Infrastructure.Repositories;

namespace TenisCourtBookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public BookingController(IApplicationDbContext applicationcontext)
        {
            _applicationDbContext = applicationcontext;
        }
        [HttpGet]
        public IActionResult ViewBookedCourt(int UserId)
        {
            try
            {
                var bookingService = new BookingService(new BookingRepository(_applicationDbContext));
                return Ok(bookingService.ViewAvailableCourt(UserId));
            }
            catch
            {
                return BadRequest("Unable to found details of court");
            }
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking obj)
        {
            try
            {
                var bookingService = new BookingService(new BookingRepository(_applicationDbContext));
                if (bookingService.UpdateBooking(obj))
                {
                    return Ok("data update succesfully");
                }
                else
                {
                    return Ok("Not updated");
                }
            }
            catch
            {
                return BadRequest("Unable to Update Data");
            }
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int BookingId)
        {
            try
            {
                var bookingService = new BookingService(new BookingRepository(_applicationDbContext));
                if (bookingService.DeleteBooking(BookingId))
                {
                    return Ok("Data deleted");
                }
                else
                {
                    return Ok("Data not Deleted");
                }
            }
            catch
            {
                return BadRequest("Their is some error in Deleteing");
            }
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking Data)
        {
            var bookingService = new BookingService(new BookingRepository(_applicationDbContext));
            try
            {
                if (bookingService.Createbooking(Data))
                {
                    return Ok("Court Booked");
                }
                else
                {
                    return Ok("Court not Booked");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
