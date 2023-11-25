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
    public class TenisCourtRepository:ITenisCourtRepository
    {
        private readonly IApplicationDbContext _context;

        public TenisCourtRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public void AddTenisCourt(TenisCourt tenisCourt)
        {
            _context.TenisCourts.Add(tenisCourt);
            _context.SaveChanges();
        }

        public bool DeleteTenisCourt(int id)
        {
            var user = _context.TenisCourts.FirstOrDefault(x => x.CourtId == id);
            if (user != null)
            {
                _context.TenisCourts.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public TenisCourt GetTenisCourt(int id)
        {
            return _context.TenisCourts.Find(id);
        }

        public TenisCourt UpdateTenisCourt(TenisCourt tenisCourt)
        {


            _context.TenisCourts.Update(tenisCourt);
            _context.SaveChanges();
            return tenisCourt;


        }

        public List<TenisCourt> ViewAllTenisCourt()
        {
            return _context.TenisCourts.ToList();
        }
    }
}
