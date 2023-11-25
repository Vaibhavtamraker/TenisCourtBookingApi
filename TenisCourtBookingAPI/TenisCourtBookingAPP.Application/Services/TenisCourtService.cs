using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;
using TenisCourtBookingAPP.Domain.Repositories;

namespace TenisCourtBookingAPP.Application.Services
{
    public class TenisCourtService
    {
        private readonly ITenisCourtRepository _tenisCourtRepository;

        public TenisCourtService(ITenisCourtRepository tenisCourtRepository)
        {
            _tenisCourtRepository = tenisCourtRepository;
        }

        public void AddTenisCourt(TenisCourt tenisCourt)
        {
            _tenisCourtRepository.AddTenisCourt(tenisCourt);
        }

        public List<TenisCourt> GetAllTenisCourt()
        {
            return _tenisCourtRepository.ViewAllTenisCourt();
        }
        public TenisCourt GetTenisCourtById(int id)
        {
            return _tenisCourtRepository.GetTenisCourt(id);
        }
        public bool RemoveCourt(int id)
        {
            return _tenisCourtRepository.DeleteTenisCourt(id);
        }

        public TenisCourt UpdateTenisCourt(TenisCourt tenis)
        {

            return _tenisCourtRepository.UpdateTenisCourt(tenis);

        }
    }
}
