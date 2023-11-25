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
    public class TenisCourtController : ControllerBase
    {
        private readonly IApplicationDbContext _context;

        public TenisCourtController(IApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetTenisCourtById(int id)
        {
            var court = new TenisCourtService(new TenisCourtRepository(_context));
            var singlecourt = court.GetTenisCourtById(id);
            return Ok(singlecourt);
        }

        [HttpPut]
        public IActionResult UpdateCourt(TenisCourt tenis)
        {
            var court = new TenisCourtService(new TenisCourtRepository(_context));
            var teniscourt = court.UpdateTenisCourt(tenis);
            return Ok(teniscourt);

        }
        [HttpPost]
        public IActionResult CreateTenisCourt(TenisCourt tenisCourt)
        {
            var tenisCourt1 = new TenisCourtService(new TenisCourtRepository(_context));
            tenisCourt1.AddTenisCourt(tenisCourt);
            return Ok("Tenis Court created successfully");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var allcourt = new TenisCourtService(new TenisCourtRepository(_context));
            if (allcourt.RemoveCourt(id))
            {
                return Ok("Court Deleted successfully");
            }
            return Ok("Court Not Deleted");
        }

        [HttpGet("GetCourts")]
        public IActionResult GetAllTenisCourt()
        {
            var allcourt = new TenisCourtService(new TenisCourtRepository(_context));
            return Ok(allcourt.GetAllTenisCourt());
        }
    }
}
